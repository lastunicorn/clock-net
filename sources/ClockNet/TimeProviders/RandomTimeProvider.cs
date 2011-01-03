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

namespace DustInTheWind.Clock.TimeProviders
{
    /// <summary>
    /// Provides random time values.
    /// </summary>
    public class RandomTimeProvider : TimeProviderBase
    {
        private Random rand;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomTimeProvider"/> class.
        /// </summary>
        public RandomTimeProvider()
            :base()
        {
            rand = new Random();
        }

        /// <summary>
        /// Returns a random time value.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing a random time value.</returns>
        public override TimeSpan GetTime()
        {
            return new TimeSpan(rand.Next(23), rand.Next(59), rand.Next(59));
        }
    }
}
