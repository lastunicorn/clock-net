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
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the ticks that mark every 5 second.
    /// </summary>
    public class Ticks5Shape : VectorialShapeBase
    {
        public override string Name
        {
            get { return "Default Ticks5 Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the ticks that mark every 5 seconds.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color used to draw the ticks that mark every 5 seconds.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }

        /// <summary>
        /// The length of the 5 second ticks. This value is given for a clock with diameter of 300px.
        /// </summary>
        private float length = 15f;

        /// <summary>
        /// Gets or sets the length of the 5 second ticks. This value is given for a clock with diameter of 300px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(15f)]
        [Description("The length of the 5 second ticks. This value is given for a clock with diameter of 300px.")]
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
        /// The width of the 5 second ticks. This value is given for a clock with diameter of 300px.
        /// </summary>
        private float thickness = 1.5f;

        /// <summary>
        /// Gets or sets the width of the 5 second ticks. This value is given for a clock with diameter of 300px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(1.5f)]
        [Description("The width of the 5 second ticks. This value is given for a clock with diameter of 300px.")]
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

        private float positionOffset = 0f;

        [Category("Appearance")]
        [DefaultValue(0f)]
        public float PositionOffset
        {
            get { return positionOffset; }
            set
            {
                positionOffset = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticks5Shape"/> class with
        /// default values.
        /// </summary>
        public Ticks5Shape()
            : this(Color.Black, 15f, 1.5f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticks5Shape"/> class.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="length"></param>
        /// <param name="thickness"></param>
        public Ticks5Shape(Color color, float length, float thickness)
            : base(color, VectorialDrawMode.Fill)
        {
            this.length = length;
            this.thickness = thickness;
        }

        public override void Draw(Graphics g)
        {
            if (length > 0 && thickness > 0)
            {
                if (pen == null)
                    pen = new Pen(outlineColor, thickness);

                g.DrawLine(pen, 0, 0 + positionOffset, 0, length + positionOffset);
            }
        }
    }
}
