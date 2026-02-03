using System.Collections.Generic;
using System.Drawing;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Properties;

namespace DustInTheWind.ClockNet.Templates
{
    public class GothicTemplate : TemplateBase
    {
        protected override IEnumerable<IShape> EnumerateShapes()
        {
            yield return new ImageBackground
            {
                Name = "Image Background",
                Image = Resources.dial,
                PinLocation = new PointF(242.5f, 242.5f)
            };

            yield return new ImageHand
            {
                Name = "Hour Hand",
                ComponentToDisplay = TimeComponent.Hour,
                Image = Resources.hour_hand,
                Length = 68f,
                Origin = new PointF(32f, 155f)
            };

            yield return new ImageHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                Image = Resources.minute_hand,
                Length = 89f,
                Origin = new PointF(14.5f, 206f)
            };

            yield return new Pin
            {
                Name = "Pin Shape",
                OutlineColor = Color.DimGray,
                Diameter = 6f
            };
        }
    }
}
