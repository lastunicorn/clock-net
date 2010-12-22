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
        public new const float HEIGHT = 37f;
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


        protected float tailLength = TAIL_LENGTH;

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

        public MinuteHandShape(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, HEIGHT, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class.
        /// </summary>
        /// <param name="color">The color of the hand.</param>
        /// <param name="fill">A value specifying if the background or the outline of the hand should be drawn.</param>
        /// <param name="height">The height of the hend for a clock of 300px.</param>
        public MinuteHandShape(Color outlineColor, Color fillColor, float height, float tailLength)
            : base(null, outlineColor, fillColor, height)
        {
            this.tailLength = tailLength;
        }

        #endregion


        protected override void CalculateDimensions()
        {
            points = new PointF[] { new PointF(0f, tailLength), new PointF(-2f, 0f), new PointF(0f, -height), new PointF(2f, 0f) };
        }
    }
}
