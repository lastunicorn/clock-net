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

using System.ComponentModel;
using System.Drawing;
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the hour hand.
    /// </summary>
    [TypeConverter(typeof(ShapeConverter))]
    public class HourHandShape : PolygonHandShape
    {
        public const string NAME = "Default Hour Hand Shape";
        public const float HEIGHT = 24.2f;
        public const float TAIL_LENGTH = 6f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return NAME; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the hour hand.
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        [Description("The color used to draw the outline of the hour hand.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the hour hand.
        /// </summary>
        [DefaultValue(typeof(Color), "RoyalBlue")]
        [Description("The color used to draw the hour hand.")]
        public override Color FillColor
        {
            get { return base.FillColor; }
            set { base.FillColor = value; }
        }

        /// <summary>
        /// Gets or sets the length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hour hand. For a clock with the diameter of 100px.")]
        public override float Height
        {
            get { return base.Height; }
            set { base.Height = value; }
        }


        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
        public override float TailLength
        {
            get { return base.TailLength; }
            set { base.TailLength = value; }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class with
        /// default values.
        /// </summary>
        public HourHandShape()
            : this(Color.Empty, Color.RoyalBlue, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline.</param>
        /// <param name="fillColor">The color used to fill the shape.</param>
        /// <param name="drawMode">Specifies if the hour hand shape should be filled with color or only draw the outline.</param>
        public HourHandShape(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline.</param>
        /// <param name="fillColor">The color used to fill the shape.</param>
        /// <param name="height">The length of the hour hand for a clock with the diameter of 100px.</param>
        public HourHandShape(Color outlineColor, Color fillColor, float height)
            : base(null, outlineColor, fillColor, height, TAIL_LENGTH)
        {
            CalculateDimensions();
        }

        #endregion


        private void CalculateDimensions()
        {
            path = new PointF[] { new PointF(0f, tailLength), new PointF(-2.5f, 0f), new PointF(0F, -height), new PointF(2.5f, 0f) };
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj is HourHandShape)
        //    {
        //        HourHandShape shape = (HourHandShape)obj;

        //        return
        //            shape.fillColor == fillColor &&
        //            shape.height == height &&
        //            shape.lineWidth == lineWidth &&
        //            shape.outlineColor == outlineColor &&
        //            shape.tailLength == tailLength &&
        //            shape.visible == visible;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public override int GetHashCode()
        //{
        //    return fillColor.GetHashCode() ^ height.GetHashCode() ^ lineWidth.GetHashCode() ^
        //        outlineColor.GetHashCode() ^ tailLength.GetHashCode() ^ visible.GetHashCode();
        //}
    }
}
