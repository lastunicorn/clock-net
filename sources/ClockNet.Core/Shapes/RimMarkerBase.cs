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

namespace DustInTheWind.ClockNet.Shapes
{
    /// <summary>
    /// The base implementation of the <see cref="IRimMarker"/> interface.
    /// Provides common functionality for all the Rim Marker Shapes.
    /// A Rim Marker is a graphical elemet (may be also numbers or text) that is displayed
    /// repeatedley around the clock's dial.
    /// Examples: the hour numbers, the minute markers, etc.
    /// </summary>
    public abstract class RimMarkerBase : ShapeBase, IRimMarker
    {
        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public const float DefaultDistanceFromEdge = 0f;

        /// <summary>
        /// The default value of the angle.
        /// </summary>
        public const float DefaultAngle = 6f;

        /// <summary>
        /// The default value of the offset angle.
        /// </summary>
        public const float DefaultOffsetAngle = 6f;

        /// <summary>
        /// The default value of the skip index.
        /// </summary>
        public const int DefaultSkipIndex = 0;

        /// <summary>
        /// The default value of the repeat.
        /// </summary>
        public const bool DefaultRepeat = true;

        /// <summary>
        /// The default value of the shape's orientation.
        /// </summary>
        public const RimMarkerOrientation DefaultOrientation = RimMarkerOrientation.FaceCenter;

        private float distanceFromEdge = DefaultDistanceFromEdge;
        private float offsetAngle = DefaultOffsetAngle;
        private float angle = DefaultAngle;
        private bool repeat = DefaultRepeat;
        private RimMarkerOrientation orientation = DefaultOrientation;

        /// <summary>
        /// Gets or sets the distance between the edge of the dial and the marker.
        /// Default value: <see cref="DefaultDistanceFromEdge"/>
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultDistanceFromEdge)]
        [Description("The distance between the edge of the dial and the marker.")]
        public virtual float DistanceFromEdge
        {
            get => distanceFromEdge;
            set
            {
                distanceFromEdge = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the angle, in degrees, between north and the first instance of the marker that is displayed.
        /// Default value: <see cref="DefaultOffsetAngle"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The offset angle should be a number greater or equal with zero.</exception>
        [Category("Layout")]
        [DefaultValue(DefaultOffsetAngle)]
        [Description("The angle, in degrees, between north and the first instance of the marker that is displayed.")]
        public virtual float OffsetAngle
        {
            get => offsetAngle;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The offset angle should be a number greater or equal with zero.");

                offsetAngle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the angle, in degrees, between two consecutive instances of the shape.
        /// Default value: <see cref="DefaultAngle"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive instances of the shape should be a positive number.</exception>
        [Category("Layout")]
        [DefaultValue(DefaultAngle)]
        [Description("The angle, in degrees, between two consecutive instances of the shape.")]
        public virtual float Angle
        {
            get => angle;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The angle between two consecutive instances of the shape should be a positive number.");

                angle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private int skipIndex;

        /// <summary>
        /// Gets or sets the index of the instance that hould not be drawn. Also, the multiples of this index are skipped.
        /// Default value: <see cref="DefaultSkipIndex"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultSkipIndex)]
        [Description("The index of the instance that hould not be drawn. Also, the multiples of this index are skipped.")]
        public virtual int SkipIndex
        {
            get => skipIndex;
            set
            {
                skipIndex = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value specifying if the shape should be repeated all around the clock's dial.
        /// Default value: <see cref="DefaultRepeat"/>
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultRepeat)]
        [Description("Specifies if the shape should be repeated all around the clock's dial.")]
        public virtual bool Repeat
        {
            get => repeat;
            set
            {
                repeat = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Geta or sets the orientation of each instance of the shape.
        /// Default value: <see cref="DefaultOrientation"/>
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultOrientation)]
        [Description("Specifies the orientation of the shape.")]
        public virtual RimMarkerOrientation Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private int index = 0;

        /// <summary>
        /// Gets or sets the index that should be drawn next time the  <see cref="IShape.Draw"/> method is called.
        /// </summary>
        [Browsable(false)]
        public int Index
        {
            get => index;
            set => index = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RimMarkerBase"/> class with
        /// default values.
        /// </summary>
        public RimMarkerBase()
            : this(DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RimMarkerBase"/> class.
        /// </summary>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="distanceFromEdge">The position offset relativelly to the edge of the dial.</param>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive drawns of the shape should be a positive number.</exception>
        public RimMarkerBase(float angle, bool repeat, float distanceFromEdge)
            : base()
        {
            if (angle <= 0)
                throw new ArgumentOutOfRangeException(nameof(angle), "The angle between two consecutive drawns of the shape should be a positive number.");

            this.angle = angle;
            this.repeat = repeat;
            this.distanceFromEdge = distanceFromEdge;
        }

        /// <summary>
        /// Performs pre-draw transformations and determines whether the drawing operation should proceed.
        /// It is expected that the necessary rotation and translation transformations are already applied
        /// to position the shape correctly on the clock's dial.
        /// This method applies additional translation and rotation transformations based on the current orientation
        /// and position settings, changing the marker position relative to its default location.
        /// Drawing is skipped if certain conditions are met, such as when the current index matches the skip interval.
        /// </summary>
        /// <param name="g">The graphics context to apply transformations to before drawing.</param>
        /// <returns><c>true</c> if drawing should continue; otherwise, <c>false</c>.</returns>
        protected override bool OnBeforeDraw(Graphics g)
        {
            bool allowToDraw = base.OnBeforeDraw(g);

            if (!allowToDraw)
                return false;

            bool shouldSkip = skipIndex > 0 && index % skipIndex == 0;

            if (shouldSkip)
                return false;

            if (distanceFromEdge != 0)
                g.TranslateTransform(0, distanceFromEdge);

            switch (orientation)
            {
                case RimMarkerOrientation.FaceCenter:
                    break;

                case RimMarkerOrientation.FaceOut:
                    g.RotateTransform(180);
                    break;

                default:
                case RimMarkerOrientation.Normal:
                    float totalAngle = -(angle * index);
                    g.RotateTransform(totalAngle);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Performs additional processing after the control has completed its drawing operations.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> object used to draw the control's content.</param>
        protected override void OnAfterDraw(Graphics g)
        {
            index++;
            base.OnAfterDraw(g);
        }

        /// <summary>
        /// Resets the index of the shape that will be drawn next.
        /// This method is called by the clock before every paint.
        /// </summary>
        public void Reset()
        {
            index = 0;
        }
    }
}
