using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DustInTheWind.Clock
{
    internal class Utils
    {
        /// <summary>
        /// Transforms the radians in degrees.
        /// </summary>
        /// <param name="radians">The radians to be transformed.</param>
        /// <returns>The degries representing the specified radians.</returns>
        protected double GetDegrees(double radians)
        {
            return (radians * 180) / Math.PI;
        }
    }
}
