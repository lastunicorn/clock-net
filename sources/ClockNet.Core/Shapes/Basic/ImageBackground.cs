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
    /// A Background Shape representing bitmap image.
    /// </summary>
    [Shape("f8f41461-b01f-44f2-8433-d5eab5678694")]
    public class ImageBackground : BackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Image Background";

        private Image image;
        private PointF pinLocation;

        /// <summary>
        /// Gets or sets the image to be drawn.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("The image to be drawn.")]
        public virtual Image Image
        {
            get => image;
            set
            {
                if (image == value)
                    return;

                image = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the location of the pin relative to the upper left corner of the image.
        /// </summary>
        [Category("Behaviour")]
        [TypeConverter(typeof(PointFConverter))]
        [Description("The location of the pin relative to the upper left corner of the image.")]
        public virtual PointF PinLocation
        {
            get => pinLocation;
            set
            {
                if (pinLocation == value)
                    return;

                pinLocation = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBackground"/> class with
        /// default values.
        /// </summary>
        public ImageBackground()
            : this(null, PointF.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBackground"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        /// <param name="pinLocation">The location of the pin relative to the upper left corner of the image.</param>
        public ImageBackground(Image image, PointF pinLocation)
            : base()
        {
            Name = DefaultName;
            this.image = image;
            this.pinLocation = pinLocation;
        }

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
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void OnDraw(Graphics g)
        {
            float height = 50f;

            if (PinLocation.Y != 0 && height > 0)
            {
                float scaleFactor = height / PinLocation.Y;
                g.ScaleTransform(scaleFactor, scaleFactor);
            }

            g.DrawImage(Image, -PinLocation.X, -PinLocation.Y, Image.Width, Image.Height);
        }
    }
}
