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
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the ticks that mark the seconds.
    /// </summary>
    public class TicksShape : LineAngularShape
    {
        /// <summary>
        /// The default value of the length.
        /// </summary>
        public const float LENGTH = 2.5f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Ticks Shape"; }
        }


        /// <summary>
        /// The length of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        protected float length;

        /// <summary>
        /// Gets or sets the length of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(LENGTH)]
        [Description("The length of the 1 second ticks. This value is given for a clock with diameter of 100px.")]
        public virtual float Length
        {
            get { return length; }
            set
            {
                length = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TicksShape"/> class with
        /// default values.
        /// </summary>
        public TicksShape()
            : this(Color.Black, LENGTH, LINE_WIDTH, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicksShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the tick shapes.</param>
        /// <param name="length">The length of the ticks.</param>
        /// <param name="lineWidth">The width of the ticks.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public TicksShape(Color color, float length, float lineWidth, float positionOffset)
            : base(PointF.Empty, PointF.Empty, color, lineWidth, 6f, true, positionOffset)
        {
            this.length = length;

            CalculateDimensions();
        }

        #endregion


        protected override void CalculateDimensions()
        {
            startPoint = new PointF(0, 0);
            endPoint = new PointF(0, length);
        }
    }
}
