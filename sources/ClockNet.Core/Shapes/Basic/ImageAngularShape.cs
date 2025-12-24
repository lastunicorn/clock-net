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
    /// An Angular Shape class that draws a bitmap image.
    /// </summary>
    [Shape("062f2c94-2c81-4241-8938-00d98741c4ab")]
    public class ImageAngularShape : AngularShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Image Angular Shape";

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
            : this(null, PointF.Empty, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAngularShape"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        public ImageAngularShape(Image image)
            : this(image, PointF.Empty, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
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
            this.Name = DefaultName;
            this.image = image;
            this.location = location;
        }

        #endregion

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig. Not even incrementing the index.
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
            g.DrawImage(image, location.X, location.Y, image.Width, image.Height);
        }
    }
}
