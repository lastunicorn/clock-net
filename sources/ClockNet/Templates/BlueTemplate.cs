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
using System.Drawing;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Core.Shapes.Default;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// Provides a predefined clock template with a blue-themed design, including default background, angular, and hand
    /// shapes.
    /// </summary>
    /// <remarks>Use this class to create a clock face with a standard set of shapes and colors suitable for
    /// blue-themed or modern clock displays. The template initializes its shape collections with default values
    /// representing a typical analog clock layout.</remarks>
    public class BlueTemplate : TemplateBase
    {
        protected override IEnumerable<IShape> EnumerateShapes()
        {
            yield return new FlatBackground
            {
                Name = "Background",
                FillColor = Color.LightBlue
            };

            yield return new StringBackground
            {
                Name = "Title",
                Location = new PointF(0, 15),
                Font = new Font("Arial", 2.5f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.DarkSlateGray,
                Text = "Blue",
            };

            yield return new Ticks
            {
                Name = "Minute Ticks",
                OutlineColor = Color.RoyalBlue,
                OutlineWidth = 0.75f,
                DistanceFromEdge = 3f,
                Length = 7.5f,
                Angle = 6f,
                SkipIndex = 5
            };

            yield return new Ticks
            {
                Name = "Hour Ticks",
                OutlineColor = Color.Navy,
                OutlineWidth = 5f,
                DistanceFromEdge = 3f,
                Length = 5f,
                Angle = 30f
            };

            yield return new HourNumerals
            {
                Name = "Hours",
                FillColor = Color.Navy,
                DistanceFromEdge = 16f
            };
        
            yield return new DiamondHand
            {
                Name = "Hour Hand",
                FillColor = Color.Navy,
                Length = 24f,
                Width = 5f,
                TailLength = 6f,
                ComponentToDisplay = TimeComponent.Hour
            };

            yield return new DiamondHand
            {
                Name = "Minute Hand",
                FillColor = Color.RoyalBlue,
                Length = 37f,
                Width = 4f,
                TailLength = 4f,
                ComponentToDisplay = TimeComponent.Minute
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                OutlineColor = Color.DeepSkyBlue,
                ComponentToDisplay = TimeComponent.Second
            };

            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.Navy
            };
        }
    }
}
