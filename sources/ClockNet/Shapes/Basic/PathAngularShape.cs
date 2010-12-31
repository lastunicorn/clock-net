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

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// An Angular Shape class that draws a <see cref="GraphicsPath"/>.
    /// </summary>
    public class PathAngularShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Path Angular Shape"; }
        }

        /// <summary>
        /// The path that is drawn.
        /// </summary>
        protected GraphicsPath path;


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PathAngularShape"/> class with
        /// default values.
        /// </summary>
        public PathAngularShape()
            : this(null, Color.Empty, Color.Black, LINE_WIDTH, ANGLE, REPEAT, POSITION_OFFSET)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathAngularShape"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        public PathAngularShape(GraphicsPath path, Color outlineColor, Color fillColor)
            : this(path, outlineColor, fillColor, LINE_WIDTH, ANGLE, REPEAT, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathAngularShape"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public PathAngularShape(GraphicsPath path, Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(outlineColor, fillColor, lineWidth, angle, repeat, positionOffset)
        {
            this.path = path;
        }

        #endregion


        protected override void DrawInternal(Graphics g)
        {
            if (path != null)
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
        }

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">Speifies if the managed resources should be disposed, too.</param>
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
