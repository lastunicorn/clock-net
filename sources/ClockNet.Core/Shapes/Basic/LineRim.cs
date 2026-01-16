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

using System.ComponentModel;
using System.Drawing;

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Rim Shape class that draws lines as items.
    /// </summary>
    [Shape("52d7515b-c6c6-44af-bf84-ffdd82238d31")]
    public class LineRim : VectorialRimBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Line Rim";

        /// <summary>
        /// Gets or sets the location of the start of the line.
        /// </summary>
        protected PointF StartPoint { get; set; }

        /// <summary>
        /// Gets or sets the location of the end of the line.
        /// </summary>
        protected PointF EndPoint { get; set; }


        /// <summary>
        /// Not used.
        /// </summary>
        [Browsable(false)]
        public override Color FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineRim"/> class with
        /// default values.
        /// </summary>
        public LineRim()
        {
            Name = DefaultName;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig. Not even incrementing the index.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !OutlineColor.IsEmpty;
        }

        /// <summary>
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected override void DrawItem(Graphics g, int index)
        {
            g.DrawLine(Pen, StartPoint, EndPoint);
        }
    }
}
