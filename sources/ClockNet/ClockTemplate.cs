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


using DustInTheWind.ClockNet.Shapes;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Keeps a collection of Shapes that can be applied to the <see cref="AnalogClock"/> all at once.
    /// </summary>
    public class ClockTemplate
    {
        #region Predefined Shape Sets

        ///// <summary>
        ///// Creates and returns a <see cref="ShapeSet"/> object that contains no Shapes.
        ///// </summary>
        //public static ShapeSet Empty
        //{
        //    get { return new ShapeSet(); }
        //}

        //public static ShapeSet WhiteFancy
        //{
        //    get
        //    {
        //        IShape[] backgrounds = new IShape[]{
        //            new DustInTheWind.Clock.Shapes.Default.DialShape(Color.Black)
        //        };

        //        TicksShape ticks1Shape = new TicksShape(Color.Black, 5f, 0.3f, 7f);
        //        ticks1Shape.Angle = 6f;
        //        ticks1Shape.ExceptionIndex = 5;

        //        TicksShape ticks5Shape = new TicksShape(Color.Black, 5f, 1f, 7f);
        //        ticks5Shape.Angle = 30f;

        //        IAngularShape[] angulars = new IAngularShape[]{
        //            ticks1Shape,
        //            ticks5Shape,
        //            new TextAngularShape(Color.White, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point), 13)
        //        };

        //        SlotHandShape hourHandShape = new SlotHandShape(Color.White, 49, 34, 6);
        //        hourHandShape.ComponentToDisplay = TimeComponent.Hour;
        //        LineHandShape minuteHandShape = new LineHandShape(Color.Black, 42, 3, 0);
        //        minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
        //        LineHandShape sweepHandShape = new LineHandShape(Color.Black, 45, 1, 15);
        //        sweepHandShape.ComponentToDisplay = TimeComponent.Second;
        //        PinShape pinShape = new PinShape(Color.Black, 9);

        //        IHandShape[] hands = new IHandShape[]{
        //            hourHandShape,
        //            minuteHandShape,
        //            sweepHandShape,
        //            pinShape
        //        };

        //        return new ShapeSet()
        //        {
        //            backgroundShapes = backgrounds,
        //            angularShapes = angulars,
        //            handShapes = hands
        //        };
        //    }
        //}

        //public static ShapeSet ImageShapes
        //{
        //    get
        //    {
        //        IShape[] backgrounds = new IShape[]{
        //            new TextShape("Image Hands", Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
        //        };

        //        TicksShape ticks1Shape = new TicksShape(Color.Black, 3.33f, 0.25f, 0f);
        //        ticks1Shape.Angle = 6f;
        //        ticks1Shape.ExceptionIndex = 5;

        //        TicksShape ticks5Shape = new TicksShape(Color.Black, 3.33f, 3f, 0f);
        //        ticks5Shape.Angle = 30f;

        //        TextAngularShape numbersShape = new TextAngularShape(Color.Black, new Font("Viner Hand ITC", 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), 5f);
        //        numbersShape.Angle = 30f;

        //        IAngularShape[] angulars = new IAngularShape[]{
        //            ticks1Shape,
        //            ticks5Shape,
        //            numbersShape
        //        };

        //        ImageHandShape hourHandShape = new ImageHandShape(Resources.hour_hand, new PointF(32f, 155.5f), 25);
        //        hourHandShape.ComponentToDisplay = TimeComponent.Hour;
        //        ImageHandShape minuteHandShape = new ImageHandShape(Resources.minute_hand, new PointF(14.5f, 206f), 35);
        //        minuteHandShape.ComponentToDisplay = TimeComponent.Minute;
        //        LineHandShape sweepHandShape = new LineHandShape(Color.Red);
        //        sweepHandShape.ComponentToDisplay = TimeComponent.Second;
        //        PinShape pinShape = new PinShape();

        //        IHandShape[] hands = new IHandShape[]{
        //            hourHandShape,
        //            minuteHandShape,
        //            sweepHandShape,
        //            pinShape
        //        };

        //        return new ShapeSet()
        //        {
        //            backgroundShapes = backgrounds,
        //            angularShapes = angulars,
        //            handShapes = hands
        //        };
        //    }
        //}

        #endregion

        /// <summary>
        /// Gets or sets the array of Shapes that are drawn on the background of the clock.
        /// </summary>
        public IGroundShape[] BackgroundShapes { get; set; }

        /// <summary>
        /// Gets or sets the array of Shapes that are drawn repetitively around the clock.
        /// </summary>
        public IAngularShape[] AngularShapes { get; set; }

        /// <summary>
        /// Gets or sets the array of Shapes that represents hands on the clock.
        /// </summary>
        public IHandShape[] HandShapes { get; set; }
    }
}
