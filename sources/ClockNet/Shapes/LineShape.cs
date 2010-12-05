// ClockControl
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

namespace DustInTheWind.Clock.Shapes
{
    public class LineShape : VectorialShapeBase
    {
        protected PointF[] path = new PointF[0];

        public override string Name
        {
            get { return "Line Shape"; }
        }

        protected float lineWidth;
        public float LineWidth
        {
            get { return lineWidth; }
            set
            {
                lineWidth = value;
                InvalidateDrawingTools();
                OnChanged(EventArgs.Empty);
            }
        }

        public LineShape(PointF[] path, Color color, float lineWidth)
            : base(color, false)
        {
            this.path = path;
            this.lineWidth = lineWidth;
        }

        public override void Draw(Graphics g)
        {
            if (pen == null)
                pen = new Pen(outlineColor, lineWidth);

            g.DrawLines(pen, path);
        }
    }
}
