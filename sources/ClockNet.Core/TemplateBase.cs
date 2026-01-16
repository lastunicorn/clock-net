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


using System.Collections.Generic;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Keeps a collection of Shapes that can be applied to the <see cref="AnalogClock"/> all at once.
    /// </summary>
    public abstract class TemplateBase
    {
        /// <summary>
        /// Gets or sets the array of Shapes that are drawn on the background of the clock.
        /// </summary>
        public List<IBackground> Backgrounds { get; }

        /// <summary>
        /// Gets or sets the array of Shapes that are drawn repetitively around the clock.
        /// </summary>
        public List<IRim> Rims { get; }

        /// <summary>
        /// Gets or sets the array of Shapes that represents hands on the clock.
        /// </summary>
        public List<IHand> Hands { get; }

        protected TemplateBase()
        {
            Backgrounds = EnumerateBackgrounds().ToList();
            Rims = EnumerateRims().ToList();
            Hands = EnumerateHands().ToList();
        }

        /// <summary>
        /// When implemented in a derived class, returns an enumerable collection of backgrounds to initialize the current template.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IBackground}"/> containing the available backgrounds. The collection may be empty
        /// if no backgrounds are defined.</returns>
        protected abstract IEnumerable<IBackground> EnumerateBackgrounds();

        /// <summary>
        /// When implemented in a derived class, returns an enumerable collection of rims to initialize the
        /// current template.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IRim}"/> containing the rims. The collection may be empty if no rims
        /// are defined.</returns>
        protected abstract IEnumerable<IRim> EnumerateRims();

        /// <summary>
        /// When implemented in a derived class, returns an enumerable collection of hands to initialize the
        /// current template.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IHand}"/> containing the hands. The collection may be empty if no hands
        /// are defined.</returns>
        protected abstract IEnumerable<IHand> EnumerateHands();
    }
}
