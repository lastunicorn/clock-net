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
using DustInTheWind.ClockNet.Shapes;
using DustInTheWind.ClockNet.Shapes.Advanced;
using DustInTheWind.ClockNet.Shapes.Basic;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Provides design time behavior for the <see cref="AnalogClock"/> control.
    /// </summary>
    public class AnalogClockDesigner : ControlDesigner
    {
        /// <summary>
        /// Initializes the <see cref="AnalogClock"/> control.
        /// </summary>
        /// <param name="defaultValues"></param>
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);


            PropertyDescriptor sizeDescriptor = TypeDescriptor.GetProperties(Component)["Size"];

            if (sizeDescriptor != null && sizeDescriptor.PropertyType == typeof(Size) && !sizeDescriptor.IsReadOnly && sizeDescriptor.IsBrowsable)
            {
                sizeDescriptor.SetValue(Component, new Size(200, 200));
            }


            PropertyDescriptor timeDescriptor = TypeDescriptor.GetProperties(Component)["Time"];

            if (timeDescriptor != null && timeDescriptor.PropertyType == typeof(TimeSpan) && !timeDescriptor.IsReadOnly && timeDescriptor.IsBrowsable)
            {
                timeDescriptor.SetValue(Component, TimeSpan.Zero);
            }


            PropertyDescriptor backgroundShapeDescriptor = TypeDescriptor.GetProperties(Component)["BackgroundShapes"];

            if (backgroundShapeDescriptor != null && backgroundShapeDescriptor.PropertyType == typeof(Collection<IBackground>) && backgroundShapeDescriptor.IsBrowsable)
            {
                Collection<IBackground> backgroundShapes = backgroundShapeDescriptor.GetValue(Component) as Collection<IBackground>;

                if (backgroundShapes != null)
                {
                    StringBackground textShape = new StringBackground("Dust in the Wind", Color.Black);
                    textShape.Location = new PointF(0f, 20f);
                    backgroundShapes.Add(textShape);
                }
            }


            PropertyDescriptor angularShapeDescriptor = TypeDescriptor.GetProperties(Component)["AngularShapes"];

            if (angularShapeDescriptor != null && angularShapeDescriptor.PropertyType == typeof(Collection<IRimMarker>) && angularShapeDescriptor.IsBrowsable)
            {
                Collection<IRimMarker> angularShapes = angularShapeDescriptor.GetValue(Component) as Collection<IRimMarker>;

                if (angularShapes != null)
                {
                    Ticks ticks1Shape = new Ticks();
                    ticks1Shape.OutlineColor = Color.Black;
                    ticks1Shape.Length = Ticks.DefaultLength;
                    ticks1Shape.OutlineWidth = Ticks.DefaultOutlineWidth;
                    ticks1Shape.DistanceFromEdge = 0f;
                    ticks1Shape.Name = "Second Ticks";
                    ticks1Shape.Angle = 6f;
                    ticks1Shape.SkipIndex = 5;
                    angularShapes.Add(ticks1Shape);

                    Ticks ticks5Shape = new Ticks();
                    ticks1Shape.OutlineColor = Color.Black;
                    ticks1Shape.Length = Ticks.DefaultLength;
                    ticks1Shape.OutlineWidth = 1f;
                    ticks1Shape.DistanceFromEdge = 0f;
                    ticks5Shape.Name = "Hour Ticks";
                    ticks5Shape.Angle = 30f;
                    ticks5Shape.Length = 5f;
                    angularShapes.Add(ticks5Shape);

                    StringRimMarker numbersShape = new StringRimMarker(Color.Black, new Font("Arial", 6.25f, FontStyle.Regular, GraphicsUnit.Point), 13f);
                    numbersShape.Name = "Hours";
                    numbersShape.Angle = 30f;
                    numbersShape.Orientation = RimMarkerOrientation.Normal;
                    angularShapes.Add(numbersShape);
                }
            }

            PropertyDescriptor handShapeDescriptor = TypeDescriptor.GetProperties(Component)["HandShapes"];

            if (handShapeDescriptor != null && handShapeDescriptor.PropertyType == typeof(Collection<IHand>) && handShapeDescriptor.IsBrowsable)
            {
                Collection<IHand> handShapes = handShapeDescriptor.GetValue(Component) as Collection<IHand>;

                if (handShapes != null)
                {
                    DiamondHand hourHandShape = new DiamondHand(Color.Empty, Color.RoyalBlue, 24f, 5f, 6f);
                    hourHandShape.Name = "Hour Hand Shape";
                    hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                    handShapes.Add(hourHandShape);

                    DiamondHand minuteHandShape = new DiamondHand(Color.Empty, Color.LimeGreen, 37f, 4f, 4f);
                    minuteHandShape.Name = "Minute Hand Shape";
                    minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                    handShapes.Add(minuteHandShape);

                    LineHand sweepHandShape = new LineHand(Color.Red);
                    sweepHandShape.Name = "Second Hand Shape";
                    sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                    sweepHandShape.Length = 42.5f;
                    handShapes.Add(sweepHandShape);

                    Pin pinShape = new Pin();
                    pinShape.FillColor = Color.Red;
                    pinShape.Diameter = Pin.DefaultDiameter;
                    pinShape.Name = "Pin Shape";
                    handShapes.Add(pinShape);
                }
            }
        }
    }
}
