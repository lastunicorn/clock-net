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
    public class Ticks1Shape : VectorialShapeBase
    {
        /// <summary>
        /// The default value of the length.
        /// </summary>
        private const float LENGTH = 2.5f;

        /// <summary>
        /// The default value of the thickness.
        /// </summary>
        private const float THICKNESS = 0.25f;

        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        private const float POSITION_OFFSET = 0f;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Ticks1 Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the ticks that mark the seconds.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color used to draw the ticks that mark the seconds.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }

        /// <summary>
        /// The length of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        private float length = LENGTH;

        /// <summary>
        /// Gets or sets the length of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(LENGTH)]
        [Description("The length of the 1 second ticks. This value is given for a clock with diameter of 100px.")]
        public float Length
        {
            get { return length; }
            set
            {
                length = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The width of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        private float thickness = THICKNESS;

        /// <summary>
        /// Gets or sets the width of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(THICKNESS)]
        [Description("The width of the 1 second ticks. This value is given for a clock with diameter of 100px.")]
        public float Thickness
        {
            get { return thickness; }
            set
            {
                thickness = value;
                InvalidateDrawingTools();
                OnChanged(EventArgs.Empty);
            }
        }

        private float positionOffset = POSITION_OFFSET;

        [Category("Appearance")]
        [DefaultValue(POSITION_OFFSET)]
        public float PositionOffset
        {
            get { return positionOffset; }
            set
            {
                positionOffset = value;
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticks1Shape"/> class with
        /// default values.
        /// </summary>
        public Ticks1Shape()
            : this(Color.Black, Color.Black, LENGTH, THICKNESS, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticks1Shape"/> class.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="length"></param>
        /// <param name="thickness"></param>
        /// <param name="positionOffset"></param>
        public Ticks1Shape(Color outlineColor, Color fillColor, float length, float thickness, float positionOffset)
            : base(outlineColor, fillColor, VectorialDrawMode.Fill)
        {
            this.length = length;
            this.thickness = thickness;
            this.positionOffset = positionOffset;
        }

        #endregion


        public override void Draw(Graphics g)
        {
            if (length > 0 && thickness > 0)
            {
                if (pen == null)
                    pen = new Pen(outlineColor, thickness);

                g.DrawLine(pen, 0, positionOffset, 0, length + positionOffset);
            }
        }
    }
}
