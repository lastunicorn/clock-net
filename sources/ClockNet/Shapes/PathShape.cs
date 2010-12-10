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

using System.Drawing;
using System.Drawing.Drawing2D;

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// A shape that draws a <see cref="GraphicsPath"/>.
    /// </summary>
    public class PathShape : VectorialShapeBase
    {
        /// <summary>
        /// The path that is drawn.
        /// </summary>
        protected GraphicsPath path;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Path Shape"; }
        }


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialShapeBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="path">The path that should be drawn.</param>
        public PathShape(Color outlineColor, Color fillColor, GraphicsPath path)
            : this(outlineColor, fillColor, LINE_WIDTH, path)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialShapeBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="path">The path that should be drawn.</param>
        public PathShape(Color outlineColor, Color fillColor, float lineWidth, GraphicsPath path)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.path = path;
        }

        #endregion


        /// <summary>
        /// Draws the path using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the path.</param>
        public override void Draw(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                g.FillPath(brush, path);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawPath(pen, path);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (path != null)
                    path.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
