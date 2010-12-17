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
using System.Windows.Forms.Design;
using DustInTheWind.Clock.Shapes;
using DustInTheWind.Clock.Shapes.Default;
using DustInTheWind.Clock.TimeProviders;

namespace DustInTheWind.Clock
{
    public class AnalogClockDesigner : ControlDesigner
    {
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);


            PropertyDescriptor timeDescriptor = TypeDescriptor.GetProperties(Component)["Time"];

            if (timeDescriptor != null && timeDescriptor.PropertyType == typeof(TimeSpan) && !timeDescriptor.IsReadOnly && timeDescriptor.IsBrowsable)
            {
                timeDescriptor.SetValue(Component, TimeSpan.Zero);
            }


            PropertyDescriptor hourHandShapeDescriptor = TypeDescriptor.GetProperties(Component)["HourHandShape"];

            if (hourHandShapeDescriptor != null && hourHandShapeDescriptor.PropertyType == typeof(IHandShape) && !hourHandShapeDescriptor.IsReadOnly && hourHandShapeDescriptor.IsBrowsable)
            {
                hourHandShapeDescriptor.SetValue(Component, new HourHandShape());
            }


            PropertyDescriptor minuteHandShapeDescriptor = TypeDescriptor.GetProperties(Component)["MinuteHandShape"];

            if (minuteHandShapeDescriptor != null && minuteHandShapeDescriptor.PropertyType == typeof(IHandShape) && !minuteHandShapeDescriptor.IsReadOnly && minuteHandShapeDescriptor.IsBrowsable)
            {
                minuteHandShapeDescriptor.SetValue(Component, new MinuteHandShape());
            }


            PropertyDescriptor sweepHandShapeDescriptor = TypeDescriptor.GetProperties(Component)["SweepHandShape"];

            if (sweepHandShapeDescriptor != null && sweepHandShapeDescriptor.PropertyType == typeof(IHandShape) && !sweepHandShapeDescriptor.IsReadOnly && sweepHandShapeDescriptor.IsBrowsable)
            {
                sweepHandShapeDescriptor.SetValue(Component, new SweepHandShape());
            }


            PropertyDescriptor pinShapeDescriptor = TypeDescriptor.GetProperties(Component)["PinShape"];

            if (pinShapeDescriptor != null && pinShapeDescriptor.PropertyType == typeof(IShape) && !pinShapeDescriptor.IsReadOnly && pinShapeDescriptor.IsBrowsable)
            {
                pinShapeDescriptor.SetValue(Component, new PinShape());
            }


            PropertyDescriptor ticks1ShapeDescriptor = TypeDescriptor.GetProperties(Component)["Ticks1Shape"];

            if (ticks1ShapeDescriptor != null && ticks1ShapeDescriptor.PropertyType == typeof(IShape) && !ticks1ShapeDescriptor.IsReadOnly && ticks1ShapeDescriptor.IsBrowsable)
            {
                ticks1ShapeDescriptor.SetValue(Component, new Ticks1Shape());
            }


            PropertyDescriptor ticks5ShapeDescriptor = TypeDescriptor.GetProperties(Component)["Ticks5Shape"];

            if (ticks5ShapeDescriptor != null && ticks5ShapeDescriptor.PropertyType == typeof(IShape) && !ticks5ShapeDescriptor.IsReadOnly && ticks5ShapeDescriptor.IsBrowsable)
            {
                ticks5ShapeDescriptor.SetValue(Component, new Ticks5Shape());
            }


            PropertyDescriptor numbersShapeDescriptor = TypeDescriptor.GetProperties(Component)["NumbersShape"];

            if (numbersShapeDescriptor != null && numbersShapeDescriptor.PropertyType == typeof(IArrayShape) && !numbersShapeDescriptor.IsReadOnly && numbersShapeDescriptor.IsBrowsable)
            {
                numbersShapeDescriptor.SetValue(Component, new NumbersShape());
            }


            PropertyDescriptor dialShapeDescriptor = TypeDescriptor.GetProperties(Component)["DialShape"];

            if (dialShapeDescriptor != null && dialShapeDescriptor.PropertyType == typeof(IShape) && !dialShapeDescriptor.IsReadOnly && dialShapeDescriptor.IsBrowsable)
            {
                dialShapeDescriptor.SetValue(Component, new DialShape());
            }


            PropertyDescriptor textShapeDescriptor = TypeDescriptor.GetProperties(Component)["TextShape"];

            if (textShapeDescriptor != null && textShapeDescriptor.PropertyType == typeof(IShape) && !textShapeDescriptor.IsReadOnly && textShapeDescriptor.IsBrowsable)
            {
                textShapeDescriptor.SetValue(Component, new TextShape());
            }


            PropertyDescriptor timeProviderDescriptor = TypeDescriptor.GetProperties(Component)["TimeProvider"];

            if (timeProviderDescriptor != null && timeProviderDescriptor.PropertyType == typeof(ITimeProvider) && !timeProviderDescriptor.IsReadOnly && timeProviderDescriptor.IsBrowsable)
            {
                timeProviderDescriptor.SetValue(Component, new LocalTimeProvider());
            }
        }
    }
}
