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

using System.Drawing;
using DustInTheWind.Clock.Properties;
using DustInTheWind.Clock.Shapes.Basic;
using DustInTheWind.Clock.Shapes.Default;
using DustInTheWind.Clock.Shapes.Fancy;

namespace DustInTheWind.Clock.Shapes
{
    public class ShapeSet
    {
        #region Predefined Shape Sets

        public static ShapeSet Empty
        {
            get { return new ShapeSet(); }
        }

        public static ShapeSet Default
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DustInTheWind.Clock.Shapes.Default.DialShape(),
                    new DustInTheWind.Clock.Shapes.Default.TextShape()
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 5f, 0.3f, 7f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 5f, 1f, 7f);
                ticks5Shape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    new TextAngularShape()
                };

                RombicHandShape hourHandShape = new RombicHandShape(Color.Empty, Color.RoyalBlue, 24f, 5f, 6f);
                hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                RombicHandShape minuteHandShape = new RombicHandShape(Color.Empty, Color.LimeGreen, 37f, 4f, 4f);
                minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                LineHandShape sweepHandShape = new LineHandShape();
                sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                PinShape pinShape = new PinShape();

                IHandShape[] hands = new IHandShape[]{
                    hourHandShape,
                    minuteHandShape,
                    sweepHandShape,
                    pinShape
                };

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    handShapes = hands
                };
            }
        }

        public static ShapeSet Blue
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DialShape(Color.LightBlue, Color.LightBlue, 1),
                    new TextShape()
                };

                TicksShape ticks1Shape = new TicksShape(Color.RoyalBlue, 7.5f, 0.75f, 5f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Navy, 5f, 15f, 5f);
                ticks5Shape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    new DustInTheWind.Clock.Shapes.Default.TextAngularShape(Color.Navy)
                };

                RombicHandShape hourHandShape = new RombicHandShape(Color.Empty, Color.Navy, 24f, 5f, 6f);
                hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                RombicHandShape minuteHandShape = new RombicHandShape(Color.Empty, Color.RoyalBlue, 37f, 4f, 4f);
                minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                LineHandShape sweepHandShape = new LineHandShape(Color.DeepSkyBlue);
                sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                PinShape pinShape = new PinShape(Color.Empty, Color.Navy);

                IHandShape[] hands = new IHandShape[]{
                    hourHandShape,
                    minuteHandShape,
                    sweepHandShape,
                    pinShape
                };

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    handShapes = hands
                };
            }
        }

        public static ShapeSet Black
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new FancyDialShape(Color.Black),
                    new TextShape("Black", Color.LightGray)
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 3f, 0.3f, 8f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.LightGray, 3f, 1f, 8f);
                ticks5Shape.Angle = 30f;

                TextAngularShape hourShapes = new TextAngularShape(Color.WhiteSmoke, new Font("Arial", 5f, FontStyle.Regular, GraphicsUnit.Point), 13f);

                TextAngularShape minuteShapes = new TextAngularShape(Color.WhiteSmoke, new Font("Arial", 2.2f, FontStyle.Regular, GraphicsUnit.Point), 0.7f);
                minuteShapes.Numbers = new string[] { "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };


                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    hourShapes,
                    minuteShapes
                };

                RombicHandShape hourHandShape = new RombicHandShape(Color.Empty, Color.RoyalBlue, 24f, 5f, 6f);
                hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                RombicHandShape minuteHandShape = new RombicHandShape(Color.Empty, Color.LimeGreen, 37f, 4f, 4f);
                minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                LineHandShape sweepHandShape = new LineHandShape(Color.Red);
                sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                sweepHandShape.Height = 42f;
                PinShape pinShape = new PinShape();

                IHandShape[] hands = new IHandShape[]{
                    hourHandShape,
                    minuteHandShape,
                    sweepHandShape,
                    pinShape
                };

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    handShapes = hands
                };
            }
        }

        public static ShapeSet Fancy
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DustInTheWind.Clock.Shapes.Default.DialShape(),
                    new DustInTheWind.Clock.Shapes.Default.TextShape()
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 3f, 0.3f, 0f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 3f, 1f, 0f);
                ticks5Shape.Angle = 30f;

                TextAngularShape numbersShape = new TextAngularShape();
                numbersShape.PositionOffset = 6f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    numbersShape
                };

                NibHandShape hourHandShape = new NibHandShape(Color.Black, 30f);
                hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                hourHandShape.Width = 5f;
                NibHandShape minuteHandShape = new NibHandShape();
                minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                FancySweepHandShape sweepHandShape = new FancySweepHandShape();
                sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                PinShape pinShape = new PinShape();

                IHandShape[] hands = new IHandShape[]{
                    hourHandShape,
                    minuteHandShape,
                    sweepHandShape,
                    pinShape
                };

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    handShapes = hands
                };
            }
        }

        public static ShapeSet Dots
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new EllipseShape(new RectangleF(-50f, -50f, 100f, 100f), Color.Empty, Color.Black, 0f),
                    new EllipseShape(new RectangleF(-48f, -48f, 96f, 96f), Color.Empty, Color.White, 0f)
                };

                IAngularShape[] angulars = null;

                DotHandShape hourHandShape = new DotHandShape(Color.Black, 20, 4.5f);
                hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                DotHandShape minuteHandShape = new DotHandShape(Color.Black, 40, 2.75f);
                minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                LineHandShape sweepHandShape = null;
                PinShape pinShape = new PinShape(Color.Black, 8);

                IHandShape[] hands = new IHandShape[]{
                    hourHandShape,
                    minuteHandShape,
                    sweepHandShape,
                    pinShape
                };

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    handShapes = hands
                };
            }
        }

        public static ShapeSet WhiteFancy
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DustInTheWind.Clock.Shapes.Default.DialShape(Color.Black)
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 5f, 0.3f, 7f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 5f, 1f, 7f);
                ticks5Shape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    new TextAngularShape(Color.White, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point), 13)
                };

                SlotHandShape hourHandShape = new SlotHandShape(Color.White, 49, 34, 6);
                hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                LineHandShape minuteHandShape = new LineHandShape(Color.Black, 42, 3, 0);
                minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                LineHandShape sweepHandShape = new LineHandShape(Color.Black, 45, 1, 15);
                sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                PinShape pinShape = new PinShape(Color.Black, 9);

                IHandShape[] hands = new IHandShape[]{
                    hourHandShape,
                    minuteHandShape,
                    sweepHandShape,
                    pinShape
                };

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    handShapes = hands
                };
            }
        }

        public static ShapeSet ImageShapes
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new TextShape("Image Hands", Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 3.33f, 0.25f, 0f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 3.33f, 3f, 0f);
                ticks5Shape.Angle = 30f;

                TextAngularShape numbersShape = new TextAngularShape(Color.Black, new Font("Viner Hand ITC", 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), 5f);
                numbersShape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    numbersShape
                };

                ImageHandShape hourHandShape = new ImageHandShape(Resources.hour_hand, new PointF(32f, 155.5f), 25);
                hourHandShape.ComponentToDisplay = TimeComponent.Hour;
                ImageHandShape minuteHandShape = new ImageHandShape(Resources.minute_hand, new PointF(14.5f, 206f), 35);
                minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
                LineHandShape sweepHandShape = new LineHandShape(Color.Red);
                sweepHandShape.ComponentToDisplay = TimeComponent.Second;
                PinShape pinShape = new PinShape();

                IHandShape[] hands = new IHandShape[]{
                    hourHandShape,
                    minuteHandShape,
                    sweepHandShape,
                    pinShape
                };

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    handShapes = hands
                };
            }
        }

        #endregion


        private IShape[] backgroundShapes;

        public IShape[] BackgroundShapes
        {
            get { return backgroundShapes; }
            set { backgroundShapes = value; }
        }

        private IAngularShape[] angularShapes;

        public IAngularShape[] AngularShapes
        {
            get { return angularShapes; }
            set { angularShapes = value; }
        }

        private IHandShape[] handShapes;

        public IHandShape[] HandShapes
        {
            get { return handShapes; }
            set { handShapes = value; }
        }
    }
}
