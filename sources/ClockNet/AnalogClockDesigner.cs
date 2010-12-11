using System.ComponentModel;
using System.Windows.Forms.Design;
using DustInTheWind.Clock.Shapes;
using DustInTheWind.Clock.Shapes.Default;

namespace DustInTheWind.Clock
{
    public class AnalogClockDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            PropertyDescriptor hourHandShapeDescriptor = TypeDescriptor.GetProperties(Component)["HourHandShape"];

            if (hourHandShapeDescriptor != null && hourHandShapeDescriptor.PropertyType == typeof(IShape) && !hourHandShapeDescriptor.IsReadOnly && hourHandShapeDescriptor.IsBrowsable)
            {
                hourHandShapeDescriptor.SetValue(Component, new HourHandShape());
            }

            PropertyDescriptor textShapeDescriptor = TypeDescriptor.GetProperties(Component)["TextShape"];

            if (textShapeDescriptor != null && textShapeDescriptor.PropertyType == typeof(IShape) && !textShapeDescriptor.IsReadOnly && textShapeDescriptor.IsBrowsable)
            {
                textShapeDescriptor.SetValue(Component, new TextShape());
            }
        }
    }
}
