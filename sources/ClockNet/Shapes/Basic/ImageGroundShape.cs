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
    /// A Shape class that draws a bitmap image.
    /// </summary>
    public class ImageGroundShape : GroundShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Image Ground Shape";

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
        /// Initializes a new instance of the <see cref="ImageGroundShape"/> class with
        /// default values.
        /// </summary>
        public ImageGroundShape()
            : this(null, PointF.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGroundShape"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        public ImageGroundShape(Image image)
            : this(image, PointF.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGroundShape"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        /// <param name="origin">The location of the pin relative to the upper left corner of the image.</param>
        public ImageGroundShape(Image image, PointF origin)
            : base()
        {
            this.Name = DefaultName;
            this.image = image;
            this.origin = origin;
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

            if (origin.Y != 0 && height > 0)
            {
                float scaleFactor = height / origin.Y;
                g.ScaleTransform(scaleFactor, scaleFactor);
            }

            g.DrawImage(image, -origin.X, -origin.Y, image.Width, image.Height);
        }
    }
}
