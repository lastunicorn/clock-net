// ClockNet
// Copyright (C) 2010 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DustInTheWind.Clock.Shapes.Fancy
{
    public class HourHandShape : VectorialClockHandBase
    {
        private GraphicsPath path;

        public override string Name
        {
            get { return "Fancy Hour Hand Shape"; }
        }

        private double GetDegries(double radians)
        {
            return (radians * 180) / Math.PI;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class with
        /// default values.
        /// </summary>
        public HourHandShape()
            : this(Color.RoyalBlue, true, 82.5f)
        {
        }

        public HourHandShape(Color color, bool fill, float height)
            : base(color, fill, height)
        {
            path = new GraphicsPath(FillMode.Alternate);
            //path.AddEllipse(-15, -15, 30, 30);
            //path.AddEllipse(-7, -7, 14, 14);
            //path.AddLines(new Point[] { new Point(-7, 0), new Point(-7, -50), new Point(-15, -50), new Point(0, -100), new Point(15, -50), new Point(7, -50), new Point(7, 0) });

            float r = 10;
            float d = r * 2;
            float l = 1.5f;
            float startAlpha = 360 - (float)GetDegries(Math.Acos(l / r));
            float alpha = 360 - 2 * (startAlpha - 270);

            // Outline
            path.AddArc(-r, -r, d, d, startAlpha, alpha);
            path.AddLines(new PointF[] { new PointF(-l, -50), new PointF(-5, -50), new PointF(0, -100), new PointF(5, -50), new PointF(l, -50) });

            //path.AddLines(new Point[] { new Point(0, 0), new Point(0, -100), new Point(100, -100), new Point(100, 0) });
            //path.CloseFigure();
            //path.AddLines(new Point[] { new Point(50, -50), new Point(50, -80), new Point(80, -80), new Point(80, -50) });
            //path.CloseFigure();
            //path.AddLines(new Point[] { new Point(20, -20), new Point(30, -20), new Point(30, -30), new Point(20, -30) });
        }

        public override void Draw(Graphics g)
        {
            if (fill)
            {
                if (brush == null)
                    brush = new SolidBrush(color);

                g.FillPath(brush, path);
            }
            else
            {
                if (pen == null)
                    pen = new Pen(color);

                g.DrawPath(pen, path);
            }
        }
    }
}
