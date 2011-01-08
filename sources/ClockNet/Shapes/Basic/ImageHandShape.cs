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

namespace DustInTheWind.ClockNet.Shapes.Basic
{
    /// <summary>
    /// Displays an image hand in the <see cref="AnalogClock"/> control.
    /// </summary>
    public class ImageHandShape : HandShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string NAME = "Image Hand Shape";


        /// <summary>
        /// The image to be drawn.
        /// </summary>
        protected Image image;

        /// <summary>
        /// Gets or sets the image to be drawn.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("The image to be drawn.")]
        public virtual Image Image
        {
            get { return image; }
            set
            {
                image = value;
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The location of the pin relative to the upper left corner of the image.
        /// </summary>
        protected PointF origin;

        /// <summary>
        /// Gets or sets the location of the pin relative to the upper left corner of the image.
        /// </summary>
        [Category("Behaviour")]
        [TypeConverter(typeof(PointFConverter))]
        [Description("The location of the pin relative to the upper left corner of the image.")]
        public virtual PointF Origin
        {
            get { return origin; }
            set
            {
                origin = value;
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageHandShape"/> class with
        /// default values.
        /// </summary>
        public ImageHandShape()
            : this(null, PointF.Empty, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageHandShape"/> class.
        /// </summary>
        /// <param name="image">The immage to be used as a clock hand.</param>
        public ImageHandShape(Image image)
            : this(image, PointF.Empty, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageHandShape"/> class.
        /// </summary>
        /// <param name="image">The immage to be used as a clock hand.</param>
        /// <param name="origin">The location of the pin relative of the top left corner of the image.</param>
        /// <param name="height">The height of the hand from the pin to the top.</param>
        public ImageHandShape(Image image, PointF origin, float height)
            : base(height)
        {
            this.Name = NAME;
            this.image = image;
            this.origin = origin;
        }

        #endregion


        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && image != null;
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="DrawInternal"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void DrawInternal(Graphics g)
        {
            if (origin.Y != 0 && height > 0)
            {
                float scaleFactor = height / origin.Y;
                g.ScaleTransform(scaleFactor, scaleFactor);
            }

            g.DrawImage(image, -origin.X, -origin.Y, image.Width, image.Height);
        }

        public override bool HitTest(PointF point)
        {
            return false;
        }
    }
}
