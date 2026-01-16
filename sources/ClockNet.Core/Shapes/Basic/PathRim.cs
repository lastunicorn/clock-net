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
    /// A Rim Shape class that draws <see cref="GraphicsPath"/> as items.
    /// </summary>
    [Shape("6f0b8ee9-2bb3-464d-ac30-d4bc7aceb611")]
    public class PathRim : VectorialRimBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Path Rim";

        /// <summary>
        /// The path that is drawn.
        /// </summary>
        protected GraphicsPath path;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathRim"/> class with
        /// default values.
        /// </summary>
        public PathRim()
            : this(null, DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathRim"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        public PathRim(GraphicsPath path, Color outlineColor, Color fillColor)
            : this(path, outlineColor, fillColor, DefaultOutlineWidth, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathRim"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public PathRim(GraphicsPath path, Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(outlineColor, fillColor, lineWidth, angle, repeat, positionOffset)
        {
            this.Name = DefaultName;
            this.path = path;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig. Not even incrementing the index.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && path != null;
        }

        /// <summary>
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected override void DrawItem(Graphics g, int index)
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
