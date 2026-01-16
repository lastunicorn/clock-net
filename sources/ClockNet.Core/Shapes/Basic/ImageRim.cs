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
    /// A Rim Shape class that draws bitmap image for items.
    /// </summary>
    [Shape("062f2c94-2c81-4241-8938-00d98741c4ab")]
    public class ImageRim : RimBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Image Rim";

        private Image image;
        private PointF location;

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
                image = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the location of the upper left corner of the image.
        /// </summary>
        [Category("Behaviour")]
        [TypeConverter(typeof(PointFConverter))]
        [Description("The location of the upper left corner of the image.")]
        public virtual PointF Location
        {
            get => location;
            set
            {
                location = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRim"/> class with
        /// default values.
        /// </summary>
        public ImageRim()
            : this(null, PointF.Empty, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRim"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        public ImageRim(Image image)
            : this(image, PointF.Empty, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRim"/> class.
        /// </summary>
        /// <param name="image">The image to be drawn.</param>
        /// <param name="location">The location of the upper left corner of the image.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public ImageRim(Image image, PointF location, float angle, bool repeat, float positionOffset)
            : base(angle, repeat, positionOffset)
        {
            Name = DefaultName;
            this.image = image;
            this.location = location;
        }

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
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected override void DrawItem(Graphics g, int index)
        {
            g.DrawImage(image, location.X, location.Y, image.Width, image.Height);
        }
    }
}
