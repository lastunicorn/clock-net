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

namespace DustInTheWind.Clock.Shapes
{
    public class ImageHandShape : ImageShape
    {
        public const float HEIGHT = 45f;

        protected float height;

        [Category("Appearance")]
        [DefaultValue(150)]
        public float Height
        {
            get { return height; }
            set
            {
                height = value;
                OnChanged(EventArgs.Empty);
            }
        }

        public ImageHandShape(Image image)
            : this(image, PointF.Empty, HEIGHT)
        {
        }

        public ImageHandShape(Image image, PointF origin, float height)
            : base(image, origin)
        {
            this.height = height;
        }

        public override void Draw(Graphics g)
        {
            if (image != null)
            {
                Matrix originalTransformMatrix = null;

                if (origin.Y != 0 && height > 0)
                {
                    originalTransformMatrix = g.Transform;

                    float scaleFactor = height / origin.Y;
                    g.ScaleTransform(scaleFactor, scaleFactor);
                }

                base.Draw(g);

                if (originalTransformMatrix != null)
                {
                    g.Transform = originalTransformMatrix;
                }
            }
        }
    }
}
