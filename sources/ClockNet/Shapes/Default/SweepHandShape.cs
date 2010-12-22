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

using System.Drawing;
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class SweepHandShape : LineHandShape
    {
        public const string NAME = "Default Sweep Hand Shape";

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return NAME; }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class with
        /// default values.
        /// </summary>
        public SweepHandShape()
            : base(Color.Red)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
        /// </summary>
        public SweepHandShape(Color color)
            : base(color)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
        /// </summary>
        public SweepHandShape(Color color, float height, float width, float tailLength)
            : base(color, height, width, tailLength)
        {
        }

        #endregion

    }
}
