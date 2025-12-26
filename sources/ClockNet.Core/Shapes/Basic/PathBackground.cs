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

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Shape class that draws a <see cref="GraphicsPath"/>.
    /// </summary>
    [Shape("38318de4-00f8-41fd-b020-0d9b6d4f2aa5")]
    public class PathBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Path Background";

        /// <summary>
        /// The path that is drawn.
        /// </summary>
        protected GraphicsPath path;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathBackground"/> class with
        /// default values.
        /// </summary>
        public PathBackground()
            : this(null, DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathBackground"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        public PathBackground(GraphicsPath path, Color outlineColor, Color fillColor)
            : this(path, outlineColor, fillColor, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathBackground"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public PathBackground(GraphicsPath path, Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.Name = DefaultName;
            this.path = path;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && path != null;
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void OnDraw(Graphics g)
        {
            if (!FillColor.IsEmpty)
                g.FillPath(Brush, path);

            if (!OutlineColor.IsEmpty)
                g.DrawPath(Pen, path);
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
