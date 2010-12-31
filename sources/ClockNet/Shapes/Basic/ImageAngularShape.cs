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

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// An Angular Shape class that draws a bitmap image.
    /// </summary>
    public class ImageAngularShape : AngularShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Image Angular Shape"; }
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
        /// The location of the upper left corner of the image.
        /// </summary>
        protected PointF location;

        /// <summary>
        /// Gets or sets the location of the upper left corner of the image.
        /// </summary>
        [Category("Behaviour")]
        [TypeConverter(typeof(PointFConverter))]
        [Description("The location of the upper left corner of the image.")]
        public virtual PointF Location
        {
            get { return location; }
            set
            {
                location = value;
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAngularShape"/> class with
        /// default values.
        /// </summary>
        public ImageAngularShape()
            : this(null, PointF.Empty, ANGLE, REPEAT, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAngularShape"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        public ImageAngularShape(Image image)
            : this(image, PointF.Empty, ANGLE, REPEAT, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAngularShape"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        /// <param name="location">The location of the upper left corner of the image.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public ImageAngularShape(Image image, PointF location, float angle, bool repeat, float positionOffset)
            : base(angle, repeat, positionOffset)
        {
            this.image = image;
            this.location = location;
        }

        #endregion


        protected override void DrawInternal(Graphics g)
        {
            if (image != null)
            {
                g.DrawImage(image, location.X, location.Y, image.Width, image.Height);
            }
        }
    }
}
