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
using System.Diagnostics;
using System.Text;

namespace DustInTheWind.ClockNet
{
    internal class PerformanceInfo
    {
        /// <summary>
        /// Counts the times the control has been repainted.
        /// </summary>
        private long sessionCount;

        /// <summary>
        /// Keeps the total time (in ticks) the control consumed executing the <see cref="OnPaint"/> method.
        /// </summary>
        private long totalTicks;

        private long lastSessionTicks;

        // Create and start a new Stopwatch.
        private Stopwatch stopwatch = new Stopwatch();

        public void Start()
        {
            stopwatch.Restart();
        }

        public void Stop()
        {
            stopwatch.Stop();

            sessionCount++;
            lastSessionTicks = stopwatch.ElapsedTicks;
            totalTicks += lastSessionTicks;
        }

        public override string ToString()
        {
            long averageTicks = totalTicks / sessionCount;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("average: " + TimeSpan.FromTicks(averageTicks).TotalMilliseconds + " ms");
            sb.AppendLine("instant: " + TimeSpan.FromTicks(lastSessionTicks).TotalMilliseconds + " ms");
            sb.AppendLine("count: " + sessionCount);

            return sb.ToString();
        }
    }
}
