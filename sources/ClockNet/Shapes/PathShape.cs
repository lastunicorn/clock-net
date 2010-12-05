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
using System.Drawing.Drawing2D;

namespace DustInTheWind.Clock.Shapes
{
    public class PathShape : VectorialShapeBase
    {
        protected GraphicsPath path;

        public override string Name
        {
            get { return "Path Shape"; }
        }

        public PathShape(GraphicsPath path, Color color, bool fill)
            : base(color, fill)
        {
            this.path = path;
        }

        public override void Draw(Graphics g)
        {
            if (fill)
            {
                if (brush == null)
                    brush = new SolidBrush(outlineColor);

                g.FillPath(brush, path);
            }
            else
            {
                if (pen == null)
                    pen = new Pen(outlineColor);

                g.DrawPath(pen, path);
            }
        }
    }
}
