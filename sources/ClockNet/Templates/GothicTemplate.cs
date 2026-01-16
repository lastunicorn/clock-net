using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Properties;

namespace DustInTheWind.ClockNet.Templates
{
    public class GothicTemplate : TemplateBase
    {
        protected override IEnumerable<IBackground> EnumerateBackgrounds()
        {
            yield return new ImageBackground
            {
                Name = "Image Background",
                Image = Resources.dial,
                PinLocation = new PointF(242.5f, 242.5f)
            };
        }

        protected override IEnumerable<IHand> EnumerateHands()
        {
            yield return new ImageHand
            {
                Name = "Hour Hand",
                ComponentToDisplay = TimeComponent.Hour,
                Image = Resources.hour_hand,
                Length = 34f,
                Origin = new PointF(32f, 155f)
            };

            yield return new ImageHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                Image = Resources.minute_hand,
                Length = 44.5f,
                Origin = new PointF(14.5f, 206f)
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                Length = 45.5f,
                OutlineColor = Color.Red,
                Visible = false
            };

            yield return new Pin
            {
                Name = "Pin Shape",
                OutlineColor = Color.DimGray,
                Diameter = 3f
            };
        }

        protected override IEnumerable<IRim> EnumerateRims()
        {
            return Enumerable.Empty<IRim>();
        }
    }
}
