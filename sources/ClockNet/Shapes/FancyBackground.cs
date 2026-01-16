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
using System.Drawing.Drawing2D;
using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// A Background Shape that draws a gradient background with two rims around it.
    /// </summary>
    [Shape("c71e41be-5254-4df4-94b0-81f3cfa6468e")]
    public class FancyBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Fancy Background";

        private RectangleF outerRimRectangle;
        private RectangleF innerRimRectangle;
        private RectangleF faceRectangle;

        #region OuterRimWidth Property

        /// <summary>
        /// The default value of the outer rim width.
        /// </summary>
        public const float DefaultOuterRimWidth = 10f;

        private float outerRimWidth = DefaultOuterRimWidth;

        /// <summary>
        /// Gets or sets the width of the outer-most rim.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultOuterRimWidth)]
        [Description("The width of the outer-most rim.")]
        public float OuterRimWidth
        {
            get => outerRimWidth;
            set
            {
                outerRimWidth = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region InnerRimWidth Property

        /// <summary>
        /// The default value of the inner rim width.
        /// </summary>
        public const float DefaultInnerRimWidth = 2f;

        private float innerRimWidth = DefaultInnerRimWidth;

        /// <summary>
        /// Gets or sets the width of the second rim.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultInnerRimWidth)]
        [Description("The width of the second rim.")]
        public float InnerRimWidth
        {
            get => innerRimWidth;
            set
            {
                innerRimWidth = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region OuterRimBrush Property (protected)

        private LinearGradientBrush outerRimBrush;

        /// <summary>
        /// Gets or sets the linear gradient brush used to render the outer rim of the control.
        /// </summary>
        /// <remarks>The brush is created using a gradient based on the current fill color and the bounds
        /// of the outer rim. The brush is lazily initialized and updated when the property is set.</remarks>
        protected LinearGradientBrush OuterRimBrush
        {
            get
            {
                if (outerRimBrush == null)
                {
                    Color outerRimColor1 = FillColor.ShiftBrighness(100f);
                    Color outerRimColor2 = FillColor.ShiftBrighness(-100f);

                    outerRimBrush = new LinearGradientBrush(outerRimRectangle, outerRimColor1, outerRimColor2, 45f);
                }

                return outerRimBrush;
            }
            private set => outerRimBrush = value;
        }

        #endregion

        #region InnerRimBrush Property (protected)

        private LinearGradientBrush innerRimBrush;

        /// <summary>
        /// Gets the linear gradient brush used to render the inner rim of the control.
        /// </summary>
        /// <remarks>The brush is created based on the current fill color and is cached for subsequent
        /// accesses. The gradient direction and colors are determined by the control's visual state.</remarks>
        protected LinearGradientBrush InnerRimBrush
        {
            get
            {
                if (innerRimBrush == null)
                {
                    Color innerRimColor1 = FillColor.ShiftBrighness(-100f);
                    Color innerRimColor2 = FillColor.ShiftBrighness(100f);

                    innerRimBrush = new LinearGradientBrush(innerRimRectangle, innerRimColor1, innerRimColor2, 45f);
                }

                return innerRimBrush;
            }
            private set => innerRimBrush = value;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FancyBackground"/> class with
        /// default values.
        /// </summary>
        public FancyBackground()
            : base(DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth)
        {
            Name = DefaultName;
        }

        /// <summary>
        /// Creates a new <see cref="Pen"/> object if it does not exist already.
        /// The pen will have an Inset alignment.
        /// </summary>
        protected override Pen CreatePen()
        {
            return new Pen(OutlineColor, OutlineWidth)
            {
                Alignment = PenAlignment.Inset
            };
        }

        /// <summary>
        /// Creates the three <see cref="Brush"/> objects if they does not exist already.
        /// </summary>
        protected override Brush CreateBrush()
        {
            Color faceColor = FillColor.ShiftSaturation(50f);
            Color faceColor1 = faceColor.ShiftBrighness(100f);
            Color faceColor2 = faceColor.ShiftBrighness(-150f);

            return new LinearGradientBrush(faceRectangle, faceColor1, faceColor2, 45f);
        }

        /// <summary>
        /// Releases resources used by the drawing tools associated with this object.
        /// </summary>
        /// <remarks>This method disposes of any managed resources related to drawing, such as brushes,
        /// and should be called when the object is no longer needed to free up system resources. Overrides the base
        /// implementation to ensure all custom drawing resources are properly released.</remarks>
        protected override void DisposeDrawingTools()
        {
            outerRimBrush?.Dispose();
            outerRimBrush = null;

            innerRimBrush?.Dispose();
            innerRimBrush = null;

            base.DisposeDrawingTools();
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            float diameter = 200f;
            float radius = diameter / 2f;

            outerRimRectangle = new RectangleF(-radius, -radius, diameter, diameter);
            innerRimRectangle = RectangleF.Inflate(outerRimRectangle, -outerRimWidth, -outerRimWidth);
            faceRectangle = RectangleF.Inflate(innerRimRectangle, -innerRimWidth, -innerRimWidth);
        }


        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (FillColor.IsEmpty)
                return false;

            return base.OnBeforeDraw(context);
        }

        /// <summary>
        /// Draws the dial's background using the provided <see cref="ClockDrawingContext"/>.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected override void OnDraw(ClockDrawingContext context)
        {
            context.Graphics.FillEllipse(OuterRimBrush, outerRimRectangle);
            context.Graphics.FillEllipse(InnerRimBrush, innerRimRectangle);
            context.Graphics.FillEllipse(Brush, faceRectangle);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">Speifies if the managed resources should be disposed, too.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                outerRimBrush?.Dispose();
                innerRimBrush?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
