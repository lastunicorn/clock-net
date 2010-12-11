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

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// Displays an image in the <see cref="AnalogClock"/> control.
    /// </summary>
    public class ImageShape : ShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Image Shape"; }
        }


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
        /// The location of the coordinate system's origin relative to the upper left corner of the image.
        /// </summary>
        protected PointF origin;

        /// <summary>
        /// Gets or sets the location of the coordinate system's origin relative to the upper left corner of the image.
        /// </summary>
        [Category("Behaviour")]
        [TypeConverter(typeof(PointFConverter))]
        [Description("The location of the coordinate system's origin relative to the upper left corner of the image.")]
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
        /// Initializes a new instance of the <see cref="ImageShape"/> class with
        /// default values.
        /// </summary>
        public ImageShape()
            : this(null, PointF.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageShape"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        public ImageShape(Image image)
            : this(image, PointF.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageShape"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        /// <param name="origin">The location of the coordinate system's origin relative to the upper left corner of the image.</param>
        public ImageShape(Image image, PointF origin)
            : base()
        {
            this.image = image;
            this.origin = origin;
        }

        #endregion


        /// <summary>
        /// Draws the image using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the image.</param>
        public override void Draw(Graphics g)
        {
            if (image != null)
            {
                g.DrawImage(image, -origin.X, -origin.Y, image.Width, image.Height);
            }
        }
    }
}
