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

namespace DustInTheWind.ClockNet.Core.Shapes
{
    /// <summary>
    /// The base implementation of the <see cref="IRim"/> interface.
    /// Provides common functionality for all the Rim Shapes.
    /// A Rim is a series of graphical elemets that are displayed repeatedley around the clock's dial.
    /// Examples: the hour numbers, the minute markers, etc.
    /// </summary>
    public abstract class RimBase : ShapeBase, IRim
    {
        #region DistanceFromEdge Property

        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public const float DefaultDistanceFromEdge = 0f;

        private float distanceFromEdge = DefaultDistanceFromEdge;

        /// <summary>
        /// Gets or sets the distance between the edge of the dial and the items.
        /// Default value: <see cref="DefaultDistanceFromEdge"/>
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultDistanceFromEdge)]
        [Description("The distance between the edge of the dial and the items.")]
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

        #endregion

        #region Angle Property

        /// <summary>
        /// The default value of the angle.
        /// </summary>
        public const float DefaultAngle = 6f;

        private float angle = DefaultAngle;

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

        #endregion

        #region OffsetAngle Property

        /// <summary>
        /// The default value of the offset angle.
        /// </summary>
        public const float DefaultOffsetAngle = 6f;

        private float offsetAngle = DefaultOffsetAngle;

        /// <summary>
        /// Gets or sets the angle, in degrees, between north and the first item that is displayed.
        /// Default value: <see cref="DefaultOffsetAngle"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The offset angle should be a number greater or equal with zero.</exception>
        [Category("Layout")]
        [DefaultValue(DefaultOffsetAngle)]
        [Description("The angle, in degrees, between north and the first item that is displayed.")]
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

        #endregion

        #region SkipIndex Property

        /// <summary>
        /// The default value of the skip index.
        /// </summary>
        public const int DefaultSkipIndex = 0;

        private int skipIndex;

        /// <summary>
        /// Gets or sets the index of the item that should not be drawn. Also, the multiples of this index are skipped.
        /// Default value: <see cref="DefaultSkipIndex"/>.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultSkipIndex)]
        [Description("The index of the item that should not be drawn. Also, the multiples of this index are skipped.")]
        public virtual int SkipIndex
        {
            get => skipIndex;
            set
            {
                skipIndex = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Repeat Property

        /// <summary>
        /// The default value of the repeat.
        /// </summary>
        public const bool DefaultRepeat = true;

        private bool repeat = DefaultRepeat;

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

        #endregion

        #region Orientation Property

        /// <summary>
        /// The default value of one item's orientation.
        /// </summary>
        public const RimItemOrientation DefaultOrientation = RimItemOrientation.FaceIn;

        private RimItemOrientation orientation = DefaultOrientation;

        /// <summary>
        /// Gets or sets the orientation of each item orientation.
        /// Default value: <see cref="DefaultOrientation"/>
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultOrientation)]
        [Description("Specifies the orientation of an item.")]
        public virtual RimItemOrientation Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region MaxCoverageCount Property

        /// <summary>
        /// The default value of the maximum coverage count.
        /// </summary>
        public const uint DefaultMaxCoverageCount = 0;

        private uint maxCoverageCount = DefaultMaxCoverageCount;

        /// <summary>
        /// Gets or sets the maximum number of items to be drawn around the dial.
        /// Default value: <see cref="DefaultMaxCoverageCount"/>
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultMaxCoverageCount)]
        [Description("The maximum number of items to be drawn around the dial.")]
        public virtual uint MaxCoverageCount
        {
            get => maxCoverageCount;
            set
            {
                maxCoverageCount = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region MaxCoverageAngle Property

        /// <summary>
        /// The default value of the maximum coverage angle.
        /// </summary>
        public const uint DefaultMaxCoverageAngle = 360;

        private uint maxCoverageAngle = DefaultMaxCoverageAngle;

        /// <summary>
        /// Gets or sets the maximum angle, in degrees, that items should cover around the dial.
        /// Default value: <see cref="DefaultMaxCoverageAngle"/>
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultMaxCoverageAngle)]
        [Description("The maximum angle, in degrees, that items should cover around the dial.")]
        public virtual uint MaxCoverageAngle
        {
            get => maxCoverageAngle;
            set
            {
                maxCoverageAngle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RimBase"/> class with
        /// default values.
        /// </summary>
        public RimBase()
            : this(DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RimBase"/> class.
        /// </summary>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="distanceFromEdge">The position offset relativelly to the edge of the dial.</param>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive drawns of the shape should be a positive number.</exception>
        public RimBase(float angle, bool repeat, float distanceFromEdge)
            : base()
        {
            if (angle <= 0)
                throw new ArgumentOutOfRangeException(nameof(angle), "The angle between two consecutive drawns of the shape should be a positive number.");

            this.angle = angle;
            this.repeat = repeat;
            this.distanceFromEdge = distanceFromEdge;
        }

        protected override void OnDraw(ClockDrawingContext context)
        {
            RimDrawingCoordinator rimDrawingCoordinator = new RimDrawingCoordinator(context.Graphics)
            {
                Diameter = context.Diameter,
                Angle = Angle,
                OffsetAngle = OffsetAngle,
                MaxCoverageCount = MaxCoverageCount,
                MaxCoverageAngle = MaxCoverageAngle,
                Repeat = Repeat,
                SkipIndex = SkipIndex,
                DistanceFromEdge = DistanceFromEdge,
                Orientation = Orientation
            };

            while (rimDrawingCoordinator.MoveNext())
            {
                DrawItem(rimDrawingCoordinator.Graphics, rimDrawingCoordinator.Index);
            }
        }

        /// <summary>
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected abstract void DrawItem(Graphics g, int index);
    }
}
