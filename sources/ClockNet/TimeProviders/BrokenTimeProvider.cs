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

namespace DustInTheWind.Clock.TimeProviders
{
    public class BrokenTimeProvider : TimeProviderBase
    {
        public const float MULTIPLIER = 10;

        TimeSpan lastValue;
        DateTime lastQueryTime;

        private float multiplier;
        [DefaultValue(MULTIPLIER)]
        public float Multiplier
        {
            get { return multiplier; }
            set
            {
                multiplier = value;
                OnChanged(EventArgs.Empty);
            }
        }

        public BrokenTimeProvider()
            : this(MULTIPLIER)
        {
        }

        public BrokenTimeProvider(float multiplier)
            : base()
        {
            this.multiplier = multiplier;
            lastQueryTime = DateTime.Now;
            lastValue = TimeSpan.Zero;
        }

        public override TimeSpan GetTime()
        {
            DateTime currentQueryTime = DateTime.Now;
            TimeSpan diffTime = currentQueryTime - lastQueryTime;
            TimeSpan deltaTime = new TimeSpan((int)(diffTime.Ticks * multiplier));
            TimeSpan newValue = lastValue + deltaTime;
            if (newValue.Days > 0)
                newValue = newValue.Subtract(TimeSpan.FromDays(newValue.Days));
            lastValue = newValue;
            lastQueryTime = currentQueryTime;

            return newValue;
        }
    }
}
