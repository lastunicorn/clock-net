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
    /// Displays an image hand in the <see cref="AnalogClock"/> control.
    /// </summary>
    [Shape("92058cfd-fe33-4b43-ac87-a3746aa92d01")]
    public class ImageHand : HandBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Image Hand";

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

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageHand"/> class with
        /// default values.
        /// </summary>
        public ImageHand()
            : this(null, PointF.Empty, DefaultLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageHand"/> class.
        /// </summary>
        /// <param name="image">The immage to be used as a clock hand.</param>
        /// <param name="origin">The location of the pin relative of the top left corner of the image.</param>
        /// <param name="length">The height of the hand from the pin to the top.</param>
        public ImageHand(Image image, PointF origin, float length)
        {
            Name = DefaultName;
            this.image = image;
            this.origin = origin;
            Length = length;
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics
        /// context.
        /// </summary>
        /// <remarks>This method is called before the drawing operation begins. Override to implement
        /// custom pre-draw logic. If the image is not set, drawing is skipped.</remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (image == null)
                return false;

            return base.OnBeforeDraw(context);
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected override void OnDraw(ClockDrawingContext context)
        {
            if (origin.Y != 0 && Length > 0)
            {
                float scaleFactor = Length / origin.Y;
                context.Graphics.ScaleTransform(scaleFactor, scaleFactor);
            }

            context.Graphics.DrawImage(image, -origin.X, -origin.Y, image.Width, image.Height);
        }

        public override bool HitTest(PointF point, TimeSpan time)
        {
            return false;
        }
    }
}
