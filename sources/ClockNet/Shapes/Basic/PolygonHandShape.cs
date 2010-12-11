// ClockControl
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

namespace DustInTheWind.Clock.Shapes.Basic
{
    public class PolygonHandShape : PolygonShape, IHandShape
    {
        public const float HEIGHT = 40f;
        public const float TAIL_LENGTH = 5f;


        public override string Name
        {
            get { return "Polygon Hand Shape"; }
        }


        /// <summary>
        /// The length of the hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hand. For a clock with the diameter of 100px.")]
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


        public PolygonHandShape()
            : this(null, Color.Empty, Color.Empty, HEIGHT, TAIL_LENGTH)
        {
        }

        public PolygonHandShape(PointF[] path, Color outlineColor, Color fillColor, float height, float tailLength)
            : base(null, outlineColor, fillColor)
        {
            this.height = height;
            this.tailLength = tailLength;

            CalculateDimensions();
        }


        protected virtual void CalculateDimensions()
        { }
    }
}
