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
using System.Drawing.Drawing2D;

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the background of the dial.
    /// </summary>
    public class DialShape : VectorialShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Dial Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the dial's background.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Red")]
        [Description("The color used to draw the dial's background.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class with
        /// default values.
        /// </summary>
        public DialShape()
            : this(Color.Empty, VectorialDrawMode.Fill)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the dial's background.</param>
        /// <param name="fill">A value specifying if the dial should be filled with color or only the border should be drown.</param>
        public DialShape(Color color, VectorialDrawMode drawMode)
            : base(color, drawMode)
        {
        }

        #endregion

        protected override void OnClockWidthChanged()
        {
            base.OnClockWidthChanged();
            CalculateDimensions();
        }

        #region Calculated Dimensions

        private float _locationX;
        private float _locationY;
        private float _width;
        private float _height;

        protected virtual void CalculateDimensions()
        {
            //_locationX = -clockWidth / 2f + lineWidth / 2f;
            //_locationY = -clockWidth / 2f + lineWidth / 2f;
            //_width = clockWidth - lineWidth;
            //_height = clockWidth - lineWidth;
            
            _locationX = -clockWidth / 2f;
            _locationY = -clockWidth / 2f;
            _width = clockWidth;
            _height = clockWidth;
        }

        #endregion

        protected override void CreatePenIfNull()
        {
            if (pen == null)
            {
                pen = new Pen(outlineColor, lineWidth);
                pen.Alignment = PenAlignment.Inset;
            }
        }

        /// <summary>
        /// Draws the dial's background using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the dial.</param>
        public override void Draw(Graphics g)
        {
            if (outlineColor != Color.Empty)
            {
                if ((drawMode & VectorialDrawMode.Fill) == VectorialDrawMode.Fill)
                {
                    CreateBrushIfNull();

                    g.FillEllipse(brush, _locationX, _locationY, _width, _height);
                }

                if ((drawMode & VectorialDrawMode.Outline) == VectorialDrawMode.Outline)
                {
                    CreatePenIfNull();

                    g.DrawEllipse(pen, _locationX, _locationY, _width, _height);
                }
            }
        }
    }
}
