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
        protected override IEnumerable<IShape> EnumerateShapes()
        {
            yield return new FlatBackground
            {
                Name = "Background",
                FillColor = Color.White,
                OutlineColor = Color.Black,
                OutlineWidth = 2
            };

            yield return new DotHand
            {
                Name = "Hour Hand",
                FillColor = Color.Black,
                Length = 50f,
                Radius = 25f,
                TimeComponent = TimeComponent.Hour,
                OutlineColor = Color.FromArgb(0x64, 0x64, 0x64),
                OutlineWidth = 1
            };

            yield return new DotHand
            {
                Name = "Minute Hand",
                FillColor = Color.Black,
                Length = 60f,
                Radius = 15f,
                TimeComponent = TimeComponent.Minute,
                OutlineColor = Color.FromArgb(0x64, 0x64, 0x64),
                OutlineWidth = 1
            };
        }
    }
}
