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

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the pin from the center of the dial.
    /// </summary>
    public class PinShape : VectorialHandShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string NAME = "Pin Shape";

        /// <summary>
        /// The default value of the diameter.
        /// </summary>
        public const float DIAMETER = 1.33f;


        /// <summary>
        /// The diameter of the pin.
        /// </summary>
        protected float diameter;

        /// <summary>
        /// Gets or sets the diameter of the pin.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [Category("Appearance")]
        [DefaultValue(DIAMETER)]
        [Description("The diameter of the pin.")]
        public float Diameter
        {
            get { return diameter; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The diameter can not be a negative value.");

                diameter = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// Not used.
        /// </summary>
        [Browsable(false)]
        public override float Height
        {
            get { return base.Height; }
            set { base.Height = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class with
        /// default values.
        /// </summary>
        public PinShape()
            : this(Color.Empty, Color.Black, DIAMETER)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to fill the pin.</param>
        /// <param name="diameter">The diameter of the pin.</param>
        public PinShape(Color fillColor, float diameter)
            : this(Color.Empty, fillColor, diameter)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the pin.</param>
        /// <param name="fillColor">The color used to fill the pin.</param>
        public PinShape(Color outlineColor, Color fillColor)
            : this(Color.Empty, fillColor, DIAMETER)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the pin.</param>
        /// <param name="fillColor">The color used to fill the pin.</param>
        /// <param name="diameter">The diameter of the pin.</param>
        public PinShape(Color outlineColor, Color fillColor, float diameter)
            : base(outlineColor, fillColor)
        {
            Name = NAME;
            this.diameter = diameter;
        }

        #region Calculated Values

        private float _locationX;
        private float _locationY;

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            _locationX = -diameter / 2f;
            _locationY = -diameter / 2f;
        }

        #endregion

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
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                g.FillEllipse(brush, _locationX, _locationY, diameter, diameter);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawEllipse(pen, _locationX, _locationY, diameter, diameter);
            }
        }

        public override bool HitTest(PointF point)
        {
            return false;
        }
    }
}
