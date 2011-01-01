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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.Design;
using DustInTheWind.Clock.Shapes;
using DustInTheWind.Clock.Shapes.Default;
using DustInTheWind.Clock.Shapes.Fancy;
using DustInTheWind.Clock.TimeProviders;
using DustInTheWind.Clock.Shapes.Basic;

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


            PropertyDescriptor backgroundShapeDescriptor = TypeDescriptor.GetProperties(Component)["BackgroundShapes"];

            if (backgroundShapeDescriptor != null && backgroundShapeDescriptor.PropertyType == typeof(Collection<IShape>) && backgroundShapeDescriptor.IsBrowsable)
            {
                Collection<IShape> backgroundShapes = backgroundShapeDescriptor.GetValue(Component) as Collection<IShape>;

                if (backgroundShapes != null)
                {
                    backgroundShapes.Add(new DialShape());
                    backgroundShapes.Add(new TextShape("Dust in the Wind", Color.Black));
                }
            }


            PropertyDescriptor angularShapeDescriptor = TypeDescriptor.GetProperties(Component)["AngularShapes"];

            if (angularShapeDescriptor != null && angularShapeDescriptor.PropertyType == typeof(Collection<IAngularShape>) && angularShapeDescriptor.IsBrowsable)
            {
                Collection<IAngularShape> angularShapes = angularShapeDescriptor.GetValue(Component) as Collection<IAngularShape>;

                if (angularShapes != null)
                {
                    TicksShape ticks1Shape = new TicksShape(Color.Black, TicksShape.LENGTH, TicksShape.LINE_WIDTH, 0f);
                    ticks1Shape.Angle = 6f;
                    ticks1Shape.ExceptionIndex = 5;
                    angularShapes.Add(ticks1Shape);

                    TicksShape ticks5Shape = new TicksShape(Color.Black, TicksShape.LENGTH, 1f, 0f);
                    ticks5Shape.Angle = 30f;
                    ticks5Shape.Length = 5f;
                    angularShapes.Add(ticks5Shape);

                    TextAngularShape numbersShape = new TextAngularShape(Color.Black, new Font("Arial", 6.25f, FontStyle.Regular, GraphicsUnit.Point), 7f);
                    numbersShape.Angle = 30f;
                    angularShapes.Add(numbersShape);
                }
            }

            PropertyDescriptor handShapeDescriptor = TypeDescriptor.GetProperties(Component)["HandShapes"];

            if (handShapeDescriptor != null && handShapeDescriptor.PropertyType == typeof(Collection<IHandShape>) && handShapeDescriptor.IsBrowsable)
            {
                Collection<IHandShape> handShapes = handShapeDescriptor.GetValue(Component) as Collection<IHandShape>;

                if (handShapes != null)
                {
                    RombicHandShape hourHandShape = new RombicHandShape(Color.Empty, Color.RoyalBlue, 24.2f, 5f, 6f);
                    hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                    handShapes.Add(hourHandShape);

                    RombicHandShape minuteHandShape = new RombicHandShape(Color.Empty, Color.LimeGreen, 37f, 4f, 4f);
                    minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                    handShapes.Add(minuteHandShape);

                    LineHandShape sweepHandShape = new LineHandShape(Color.Red);
                    sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                    sweepHandShape.Height = 42.5f;
                    handShapes.Add(sweepHandShape);

                    PinShape pinShape = new PinShape();
                    handShapes.Add(pinShape);
                }
            }


            //PropertyDescriptor timeProviderDescriptor = TypeDescriptor.GetProperties(Component)["TimeProvider"];

            //if (timeProviderDescriptor != null && timeProviderDescriptor.PropertyType == typeof(ITimeProvider) && !timeProviderDescriptor.IsReadOnly && timeProviderDescriptor.IsBrowsable)
            //{
            //    LocalTimeProvider timeProvider = new LocalTimeProvider();
            //    timeProviderDescriptor.SetValue(Component, new LocalTimeProvider());
            //}
        }
    }
}
