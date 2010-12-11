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
using System.Drawing.Drawing2D;

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// Displays an image hand in the <see cref="AnalogClock"/> control.
    /// </summary>
    public class ImageHandShape : ImageShape, IHandShape
    {
        /// <summary>
        /// The default height of the hand.
        /// </summary>
        public const float HEIGHT = 45f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Image Hand Shape"; }
        }


        /// <summary>
        /// The height of the hand. If the image's height is different then this value, a scale is performed.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the height of the hand. If the image's height is different then this value, a scale is performed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(150)]
        [Description("The height of the hand.")]
        public virtual float Height
        {
            get { return height; }
            set
            {
                height = value;
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// Not used. Returns always 0.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float TailLength
        {
            get { return 0f; }
            set { }
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
            : base(image, origin)
        {
            this.height = height;
        }

        #endregion


        /// <summary>
        /// Draws the image representing the hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the image.</param>
        /// <remarks>
        /// The hand is drawn in vertical position from the origin of the coordinate system.
        /// Before this method beeng called, the coordinate system has to be rotated in the corect position.
        /// </remarks>
        public override void Draw(Graphics g)
        {
            if (visible && image != null)
            {
                Matrix originalTransformMatrix = null;

                if (origin.Y != 0 && height > 0)
                {
                    originalTransformMatrix = g.Transform;

                    float scaleFactor = height / origin.Y;
                    g.ScaleTransform(scaleFactor, scaleFactor);
                }

                base.Draw(g);

                if (originalTransformMatrix != null)
                {
                    g.Transform = originalTransformMatrix;
                }
            }
        }
    }
}
