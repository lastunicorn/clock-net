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

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// The base implementation of the <see cref="IGroundShape"/> interface.
    /// Provides common functionality for all the Background Shapes.
    /// </summary>
    public abstract class GroundShapeBase : ShapeBase, IGroundShape
    {
        [Browsable(false)]
        public int a { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GroundShapeBase"/> class with
        /// default values.
        /// </summary>
        public GroundShapeBase()
            : base()
        {
        }

        #endregion
    }
}
