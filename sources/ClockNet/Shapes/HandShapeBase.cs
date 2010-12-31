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

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// The base class for a shape that represents a clock hand.
    /// </summary>
    public abstract class HandShapeBase : ShapeBase, IHandShape
    {
        /// <summary>
        /// The default value of the height.
        /// </summary>
        public const float HEIGHT = 45f;


        /// <summary>
        /// The length of the hand from the pin to the its top. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hand from the pin to the its top. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hand from the pin to the its top. For a clock with the diameter of 100px.")]
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


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HandShapeBase"/> class with
        /// default values.
        /// </summary>
        public HandShapeBase()
            : this(HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HandShapeBase"/> class.
        /// </summary>
        /// <param name="height">The length of the hour hand for a clock with the diameter of 100px.</param>
        public HandShapeBase(float height)
            : base()
        {
            this.height = height;
        }

        #endregion


        ///// <summary>
        ///// Performs all the necessary calculations based on the public parameters, before drawing the shape.
        ///// </summary>
        //protected virtual void CalculateDimensions() { }
    }
}
