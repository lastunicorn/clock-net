using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Default;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// Defines a watch face template with a white background and black disks as hands.
    /// </summary>
    public class PandaTemplate : TemplateBase
    {
        protected override IEnumerable<IBackground> EnumerateBackgrounds()
        {
            yield return new FlatBackground
            {
                Name = "Black Margin",
                FillColor = Color.Black
            };

            yield return new FlatBackground
            {
                Name = "White Background",
                FillColor = Color.White,
                Radius = 96f
            };
        }

        protected override IEnumerable<IRim> EnumerateRims()
        {
            return Enumerable.Empty<IRim>();
        }

        protected override IEnumerable<IHand> EnumerateHands()
        {
            yield return new DotHand
            {
                Name = "Hour Hand",
                FillColor = Color.Black,
                Length = 50f,
                Radius = 18f,
                ComponentToDisplay = TimeComponent.Hour,
                OutlineColor = Color.FromArgb(0x64, 0x64, 0x64)
            };

            yield return new DotHand
            {
                Name = "Minute Hand",
                FillColor = Color.Black,
                Length = 60f,
                Radius = 12f,
                ComponentToDisplay = TimeComponent.Minute,
                OutlineColor = Color.FromArgb(0x64, 0x64, 0x64)
            };

            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.Black,
                OutlineColor = Color.FromArgb(0x64, 0x64, 0x64),
                Diameter = 4f
            };
        }
    }
}
