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
using System.ComponentModel;
using System.Drawing;

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Background Shape representing a line.
    /// </summary>
    [Shape("8dccd001-47d8-4b7b-9330-7d832c262858")]
    public class LineBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Line Background";

        private PointF startPoint;
        private PointF endPoint;

        /// <summary>
        /// Gets or sets the starting point of the line, in client coordinates.
        /// </summary>
        [Category("Appearance")]
        [TypeConverter(typeof(PointFConverter))]
        public PointF StartPoint
        {
            get => startPoint;
            set
            {
                if (startPoint == value)
                    return;

                startPoint = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the ending point of the line, in client coordinates.
        /// </summary>
        [Category("Appearance")]
        [TypeConverter(typeof(PointFConverter))]
        public PointF EndPoint
        {
            get => endPoint;
            set
            {
                if (endPoint == value)
                    return;

                endPoint = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineBackground"/> class with
        /// default values.
        /// </summary>
        public LineBackground()
            : base(Color.Black, Color.Empty, DefaultOutlineWidth)
        {
            Name = DefaultName;
            startPoint = new PointF(-15f, 0);
            endPoint = new PointF(15f, 0);
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() &&
                !OutlineColor.IsEmpty &&
                StartPoint != PointF.Empty &&
                EndPoint != PointF.Empty &&
                StartPoint != EndPoint;
        }

        /// <summary>
        /// Draws the line onto the specified graphics surface using the configured pen and endpoints.
        /// </summary>
        /// <remarks>This method is typically called by the rendering system and should not be invoked
        /// directly. The line is drawn from <see cref="StartPoint"/> to <see cref="EndPoint"/> using <see cref="Pen"/>.</remarks>
        /// <param name="g">The <see cref="Graphics"/> object on which the line will be rendered. Must not be null.</param>
        protected override void OnDraw(Graphics g)
        {
            g.DrawLine(Pen, StartPoint, EndPoint);
        }
    }
}
