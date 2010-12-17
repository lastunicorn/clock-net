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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// A shape that draws a clock hand using a <see cref="GraphicsPath"/>.
    /// </summary>
    public class PathHandShape : PathShape, IHandShape
    {
        /// <summary>
        /// The default length of the hand from the pin to the top.
        /// </summary>
        public const float HEIGHT = 42.5f;

        /// <summary>
        /// The default value of the hand width.
        /// </summary>
        public new const float LINE_WIDTH = 0.3f;

        /// <summary>
        /// The default value of the hand's tail length.
        /// </summary>
        public const float TAIL_LENGTH = 5f;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Path Hand Shape"; }
        }


        /// <summary>
        /// The length of the hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hand. For a clock with the diameter of 100px.")]
        public virtual float Height
        {
            get { return height; }
            set
            {
                height = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The length of the hand's tail that is drawn on the other side of the pin.
        /// </summary>
        protected float tailLength;

        /// <summary>
        /// Gets or set the length of the hand's tail that is drawn on the other side of the pin.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
        [Description("The length of the hand's tail that is drawn on the other side of the pin.")]
        public virtual float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="path">The path that should be drawn.</param>
        public PathHandShape(Color outlineColor, Color fillColor, GraphicsPath path)
            : this(outlineColor, fillColor, LINE_WIDTH, path)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="path">The path that should be drawn.</param>
        public PathHandShape(Color outlineColor, Color fillColor, float lineWidth, GraphicsPath path)
            : base(outlineColor, fillColor, lineWidth, path)
        {
            this.path = path;
        }

        #endregion


        protected virtual void CalculateDimensions() { }

        /// <summary>
        /// Draws the hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the hand.</param>
        public override void Draw(Graphics g)
        {
            if (visible)
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
