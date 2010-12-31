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
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the minute hand.
    /// </summary>
    public class MinuteHandShape : PolygonHandShape
    {
        public const string NAME = "Default Minute Hand Shape";

        /// <summary>
        /// The default value of the <see cref="Height"/>.
        /// </summary>
        public new const float HEIGHT = 37f;

        /// <summary>
        /// The default value of the <see cref="TailLength"/>.
        /// </summary>
        public new const float TAIL_LENGTH = 4f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return NAME; }
        }


        /// <summary>
        /// Gets or sets the color used to draw the minute hand.
        /// </summary>
        [DefaultValue(typeof(Color), "LimeGreen")]
        [Description("The color used to draw the minute hand.")]
        public override Color FillColor
        {
            get { return base.FillColor; }
            set { base.FillColor = value; }
        }

        /// <summary>
        /// Gets or sets the length of the minute hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the minute hand. For a clock with the diameter of 100px.")]
        public override float Height
        {
            get { return base.Height; }
            set { base.Height = value; }
        }


        /// <summary>
        /// The length of the hand's tail from the pin to the bottom.
        /// </summary>
        protected float tailLength = TAIL_LENGTH;

        /// <summary>
        /// Gets or sets the length of the hand's tail from the pin to the bottom.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
        public virtual float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class with
        /// default values.
        /// </summary>
        public MinuteHandShape()
            : this(Color.Empty, Color.LimeGreen, HEIGHT, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        public MinuteHandShape(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, HEIGHT, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The height of the hend (from the pin to the top) for a clock of 300px.</param>
        /// <param name="tailLength">The length of the hand's tail.</param>
        public MinuteHandShape(Color outlineColor, Color fillColor, float height, float tailLength)
            : base(null, outlineColor, fillColor, height, LINE_WIDTH)
        {
            this.tailLength = tailLength;

            CalculateDimensions();
        }

        #endregion


        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateDimensions()
        {
            points = new PointF[] { new PointF(0f, tailLength), new PointF(-2f, 0f), new PointF(0f, -height), new PointF(2f, 0f) };
        }
    }
}
