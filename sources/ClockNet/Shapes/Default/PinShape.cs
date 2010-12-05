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
        /// Gets or sets the color used to draw the pin.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Red")]
        [Description("The color used to draw the pin.")]
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
            : this(Color.Red, VectorialDrawMode.Fill, RADIUS)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the pin.</param>
        /// <param name="fill">A value specifying if the pin should be filled with color.</param>
        public PinShape(Color color, VectorialDrawMode drawMode)
            : this(color, drawMode, RADIUS)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the pin.</param>
        /// <param name="fill">A value specifying if the pin should be filled with color.</param>
        /// <param name="radiusPercentage">The radius of the pin as percentage from the width of the clock.</param>
        public PinShape(Color color, VectorialDrawMode drawMode, float radiusPercentage)
            : base(color, drawMode)
        {
            this.radius = radiusPercentage;
            CalculateDimensions();
        }

        #endregion


        protected override void OnClockWidthChanged()
        {
            base.OnClockWidthChanged();
            CalculateDimensions();
        }

        #region Calculated Values

        private float _locationX;
        private float _locationY;
        private volatile float _radius;

        private void CalculateDimensions()
        {
            _radius = radius * clockWidth / 100;
            _locationX = -_radius / 2f;
            _locationY = -_radius / 2f;
        }

        #endregion

        /// <summary>
        /// Draws the pin using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the pin.</param>
        public override void Draw(Graphics g)
        {
            if ((drawMode & VectorialDrawMode.Fill) == VectorialDrawMode.Fill)
            {
                if (brush == null)
                    brush = new SolidBrush(fillColor);

                g.FillEllipse(brush, _locationX, _locationY, _radius, _radius);
            }

            if ((drawMode & VectorialDrawMode.Outline) == VectorialDrawMode.Outline)
            {
                if (pen == null)
                    pen = new Pen(outlineColor);

                g.DrawEllipse(pen, _locationX, _locationY, _radius, _radius);
            }
        }
    }
}
