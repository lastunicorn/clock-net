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
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Fancy
{
    public class SlotHandShape : PathShape, IHandShape
    {
        public const float SLOT_WIDTH = 5f;
        public const float SLOT_HEIGHT = 40f;
        public const float HEIGHT = 50f;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Slot Hand Shape"; }
        }


        /// <summary>
        /// The length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hour hand. For a clock with the diameter of 100px.")]
        public virtual float Height
        {
            get { return height; }
            set
            {
                height = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        protected float tailLength;
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


        protected float slotWidth;
        public virtual float SlotWidth
        {
            get { return slotWidth; }
            set
            {
                slotWidth = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        protected float slotHeight;
        public virtual float SlotHeight
        {
            get { return slotHeight; }
            set
            {
                slotHeight = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotHandShape"/> class with
        /// default values.
        /// </summary>
        public SlotHandShape()
            : this(Color.Empty, Color.RoyalBlue, HEIGHT, SLOT_HEIGHT, SLOT_WIDTH)
        {
        }

        public SlotHandShape(Color fillColor, float height, float slotHeight, float slotWidth)
            : this(Color.Empty, fillColor, height, slotHeight, slotWidth)
        {
        }

        public SlotHandShape(Color outlineColor, Color fillColor, float height, float slotHeight, float slotWidth)
            : base(outlineColor, fillColor, new GraphicsPath())
        {
            this.height = height;
            this.slotHeight = slotHeight;
            this.slotWidth = slotWidth;

            CalculateDimensions();
        }

        #endregion

        private void CalculateDimensions()
        {
            path.Reset();
            path.AddEllipse(-height, -height, height * 2f, height * 2f);
            path.AddRectangle(new RectangleF(-slotWidth / 2f, -slotHeight, slotWidth, slotHeight + tailLength));
        }
    }
}
