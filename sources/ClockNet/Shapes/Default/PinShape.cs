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

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the pin from the center of the dial.
    /// </summary>
    public class PinShape : VectorialShapeBase
    {
        /// <summary>
        /// The default value of the radius.
        /// </summary>
        private const float RADIUS = 1.33f;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Pin Shape"; }
        }

        /// <summary>
        /// The radius of the pin.
        /// </summary>
        protected float radius;

        /// <summary>
        /// Gets or sets the radius of the pin.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(RADIUS)]
        [Description("The radius of the pin.")]
        public float Radius
        {
            get { return radius; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The radius can not be a negative value.");

                radius = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the color used to fill the pin.
        /// </summary>
        [DefaultValue(typeof(Color), "Red")]
        [Description("The color used to fill the pin.")]
        public override Color FillColor
        {
            get { return base.FillColor; }
            set { base.FillColor = value; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the outline of the pin.
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("The color used to draw the outline of the pin.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class with
        /// default values.
        /// </summary>
        public PinShape()
            : this(Color.Empty, Color.Red, RADIUS)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the pin.</param>
        /// <param name="radius">The radius of the pin.</param>
        public PinShape(Color fillColor, float radius)
            : this(Color.Empty, fillColor, radius)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        public PinShape(Color outlineColor, Color fillColor)
            : this(Color.Empty, fillColor, RADIUS)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="radius">The radius of the pin.</param>
        public PinShape(Color outlineColor, Color fillColor, float radius)
            : base(outlineColor, fillColor)
        {
            this.radius = radius;

            CalculateDimensions();
        }

        #endregion


        #region Calculated Values

        private float _locationX;
        private float _locationY;

        protected virtual void CalculateDimensions()
        {
            _locationX = -radius / 2f;
            _locationY = -radius / 2f;
        }

        #endregion

        /// <summary>
        /// Draws the pin using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the pin.</param>
        public override void Draw(Graphics g)
        {
            if (visible)
            {
                if (!fillColor.IsEmpty)
                {
                    CreateBrushIfNull();

                    g.FillEllipse(brush, _locationX, _locationY, radius, radius);
                }

                if (!outlineColor.IsEmpty)
                {
                    CreatePenIfNull();

                    g.DrawEllipse(pen, _locationX, _locationY, radius, radius);
                }
            }
        }
    }
}
