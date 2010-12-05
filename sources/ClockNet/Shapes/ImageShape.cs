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

namespace DustInTheWind.Clock.Shapes
{
    public class ImageShape : ShapeBase
    {
        public override string Name
        {
            get { return "Image Shape"; }
        }

        protected Image image;

        [Category("Appearance")]
        [DefaultValue(null)]
        //[TypeConverter(typeof(ImageConverter))]
        //[Editor(typeof(ImageEditor), typeof(UITypeEditor))]
        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                OnChanged(EventArgs.Empty);
            }
        }

        protected PointF origin;

        [Category("Behaviour")]
        [TypeConverter(typeof(PointFConverter))]
        public PointF Origin
        {
            get { return origin; }
            set
            {
                origin = value;
                OnChanged(EventArgs.Empty);
            }
        }

        public ImageShape(Image image)
            : this(image, PointF.Empty)
        {
        }

        public ImageShape(Image image, PointF origin)
            : base()
        {
            this.image = image;
            this.origin = origin;
        }

        public override void Draw(Graphics g)
        {
            if (image != null)
            {
                g.DrawImage(image, -origin.X, -origin.Y, image.Width, image.Height);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }

            base.Dispose(disposing);
        }
    }
}
