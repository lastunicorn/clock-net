using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// Draws a shape repeatedly at different angles on the clock.
    /// The angles are measured from the 12 o'clock hour.
    /// The first shape is drawn in the first position after the 12 o'clock hour. The 12 o'clock hour position is drawn last.
    /// </summary>
    public interface IAngularShape : IShape
    {
        /// <summary>
        /// Gets or sets the angle at which the shape should be drawn.
        /// </summary>
        float Angle { get; set; }

        /// <summary>
        /// Gets or sets a value specifying if the shape should be repeated at regular angle intervals.
        /// </summary>
        bool Repeat { get; set; }

        /// <summary>
        /// Gets or sets the index of the shape that will be drawn next.
        /// This value is automatically incremented after a coll of the <see cref="Draw"/> method.
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Resets the index of the shape that will be drawn next.
        /// This method is called by the clock before every paint.
        /// </summary>
        void Reset();
    }
}
