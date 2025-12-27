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
using System.Drawing;
using System.Windows.Forms.Design;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Core.Shapes.Default;
using DustInTheWind.ClockNet.Templates;

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

            DescribeSizeProperty();
            DescribeTimeProperty();

            DefaultTemplate defaultTemplate = new DefaultTemplate();
            (Component as AnalogClock).ApplyTemplate(defaultTemplate);
            //DescribeBackgroundsProperty();
            //DescribeRimMarkersProperty();
            //DescribeHandsProperty();
        }

        private void DescribeSizeProperty()
        {
            PropertyDescriptor sizeDescriptor = TypeDescriptor.GetProperties(Component)[nameof(AnalogClock.Size)];

            if (sizeDescriptor != null && sizeDescriptor.PropertyType == typeof(Size) && !sizeDescriptor.IsReadOnly && sizeDescriptor.IsBrowsable)
            {
                sizeDescriptor.SetValue(Component, new Size(200, 200));
            }
        }

        private void DescribeTimeProperty()
        {
            PropertyDescriptor timeDescriptor = TypeDescriptor.GetProperties(Component)[nameof(AnalogClock.Time)];

            if (timeDescriptor != null && timeDescriptor.PropertyType == typeof(TimeSpan) && !timeDescriptor.IsReadOnly && timeDescriptor.IsBrowsable)
            {
                timeDescriptor.SetValue(Component, TimeSpan.Zero);
            }
        }

        private void DescribeBackgroundsProperty()
        {
            PropertyDescriptor backgroundDescriptor = TypeDescriptor.GetProperties(Component)[nameof(AnalogClock.Backgrounds)];

            if (backgroundDescriptor != null && backgroundDescriptor.PropertyType == typeof(ShapeCollection<IBackground>) && backgroundDescriptor.IsBrowsable)
            {
                if (backgroundDescriptor.GetValue(Component) is ShapeCollection<IBackground> backgrounds)
                {
                    StringBackground textShape = new StringBackground
                    {
                        Text = "Dust in the Wind",
                        FillColor = Color.Black,
                        Location = new PointF(0f, 20f)
                    };
                    backgrounds.Add(textShape);
                }
            }
        }

        private void DescribeRimMarkersProperty()
        {
            PropertyDescriptor rimMarkerDescriptor = TypeDescriptor.GetProperties(Component)[nameof(AnalogClock.RimMarkers)];

            if (rimMarkerDescriptor != null && rimMarkerDescriptor.PropertyType == typeof(ShapeCollection<IRimMarker>) && rimMarkerDescriptor.IsBrowsable)
            {
                if (rimMarkerDescriptor.GetValue(Component) is ShapeCollection<IRimMarker> rimMarkers)
                {
                    Ticks swipeTicks = new Ticks
                    {
                        Name = "Minute Ticks",
                        SkipIndex = 5
                    };
                    rimMarkers.Add(swipeTicks);

                    Ticks hourTicks = new Ticks
                    {
                        Name = "Hour Ticks",
                        OutlineWidth = 1f,
                        Angle = 30f
                    };
                    rimMarkers.Add(hourTicks);

                    Hours hours = new Hours();
                    rimMarkers.Add(hours);
                }
            }
        }

        private void DescribeHandsProperty()
        {
            PropertyDescriptor handDescriptor = TypeDescriptor.GetProperties(Component)[nameof(AnalogClock.Hands)];

            if (handDescriptor != null && handDescriptor.PropertyType == typeof(ShapeCollection<IHand>) && handDescriptor.IsBrowsable)
            {
                if (handDescriptor.GetValue(Component) is ShapeCollection<IHand> hands)
                {
                    DiamondHand hourHandShape = new DiamondHand
                    {
                        Name = "Hour Hand",
                        ComponentToDisplay = TimeComponent.Hour,
                        OutlineColor = Color.Empty,
                        FillColor = Color.RoyalBlue,
                        Length = 24f,
                        Width = 5f,
                        TailLength = 6f
                    };
                    hands.Add(hourHandShape);

                    DiamondHand minuteHandShape = new DiamondHand
                    {
                        Name = "Minute Hand",
                        ComponentToDisplay = TimeComponent.Minute,
                        OutlineColor = Color.Empty,
                        FillColor = Color.LimeGreen,
                        Length = 37f,
                        Width = 4f,
                        TailLength = 4f

                    };
                    hands.Add(minuteHandShape);

                    LineHand sweepHandShape = new LineHand
                    {
                        Name = "Second Hand",
                        ComponentToDisplay = TimeComponent.Second,
                        OutlineColor = Color.Red,
                        Length = 42.5f
                    };
                    hands.Add(sweepHandShape);

                    Pin pinShape = new Pin
                    {
                        FillColor = Color.Red,
                        Diameter = Pin.DefaultDiameter,
                        Name = "Pin Shape"
                    };
                    hands.Add(pinShape);
                }
            }
        }
    }
}
