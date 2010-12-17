using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using DustInTheWind.Clock.Shapes;

namespace DustInTheWind.Clock.Shapes.Fancy
{
    public class BigRainDropHandShape : DustInTheWind.Clock.Shapes.Basic.PathShape, IHandShape
    {
        public BigRainDropHandShape()
            : base(Color.Empty, Color.Black, new GraphicsPath())
        {
            height = 45f;
            Calculate();
        }

        private void Calculate()
        {
            path.Reset();

            path.AddArc(new RectangleF(-10f, 41f, 20f, 20f), -60f, 300f);

            path.AddCurve(new PointF[] {
                new PointF(-10f * (float)Math.Cos(Math.PI / 3f), 41f * (float)Math.Sin(Math.PI / 3f)),
                new PointF(-4f, 39f),
                new PointF(-8f, 35f)
            });

            path.AddCurve(new PointF[] {
                new PointF(-8f, 35f),
                new PointF(-4f, 29f),
                new PointF(-2f, 11f)
            });

            path.AddArc(new RectangleF(-12f, -13f, 24, 24), 90, 90);

            path.AddCurve(new PointF[] {
                new PointF(-12f, -1f),
                new PointF(-12f, -7f),
                new PointF(-2f, -59f),
                new PointF(-10f, -119f)
            });

            path.AddCurve(new PointF[] {
                new PointF(-10f, -119f),
                new PointF(-5f, -124f),
                new PointF(-3f, -129f)
            });

            path.AddArc(new RectangleF(-15f, -159f, 30f, 30f), 90f, 90f);

            path.AddCurve(new PointF[] {
                new PointF(-15f, -144f),
                new PointF(-14f, -151f),
                new PointF(-3f, -199f),
                new PointF(-1f, -249f)
            });

            path.AddLine(new PointF(-1f, -249f), new PointF(-1f, -280f));

            // <- center

            path.AddLine(new PointF(1f, -280f), new PointF(1f, -249f));

            path.AddCurve(new PointF[] {
                new PointF(1f, -249f),
                new PointF(3f, -199f),
                new PointF(14f, -151f),
                new PointF(15f, -144f)
            });

            path.AddArc(new RectangleF(-15f, -159f, 30f, 30f), 0f, 90f);

            path.AddCurve(new PointF[] {
                new PointF(3f, -129f),
                new PointF(5f, -124f),
                new PointF(10f, -119f)
            });

            path.AddCurve(new PointF[] {
                new PointF(10f, -119f),
                new PointF(2f, -59f),
                new PointF(12f, -7f),
                new PointF(12f, -1f)
            });

            path.AddArc(new RectangleF(-12f, -13f, 24f, 24f), 0f, 90f);

            path.AddCurve(new PointF[] {
                new PointF(2f, 11f),
                new PointF(4f, 29f),
                new PointF(8f, 35f)
            });

            path.AddCurve(new PointF[] {
                new PointF(8f, 35f),
                new PointF(4f, 39f),
                new PointF(10f * (float)Math.Cos(Math.PI / 3f), 41f * (float)Math.Sin(Math.PI / 3f))
            });
        }

        //private void Calculate()
        //{
        //    path.Reset();

        //    path.AddArc(new RectangleF(-10f, -10f, 20f, 20f), -60f, 300f);

        //    path.AddCurve(new PointF[] {
        //    new PointF(-10f * (float)Math.Cos(Math.PI / 3f), -10f * (float)Math.Sin(Math.PI / 3f)),
        //    new PointF(-4f,-12f),
        //    new PointF(-8f, -16f)
        //});

        //    path.AddCurve(new PointF[] {
        //    new PointF(-8f, -16f),
        //    new PointF(-4f, -22f),
        //    new PointF(-2f, -40f)
        //});

        //    path.AddArc(new RectangleF(-12f, -64f, 24, 24), 90, 90);

        //    path.AddCurve(new PointF[] {
        //    new PointF(-12f, -52f),
        //    new PointF(-12f, -58f),
        //    new PointF(-2f, -110f),
        //    new PointF(-10f, -170f)
        //});

        //    path.AddCurve(new PointF[] {
        //    new PointF(-10f, -170f),
        //    new PointF(-5f, -175f),
        //    new PointF(-3f, -180f)
        //});

        //    path.AddArc(new RectangleF(-15f, -210f, 30f, 30f), 90f, 90f);

        //    path.AddCurve(new PointF[] {
        //    new PointF(-15f, -195f),
        //    new PointF(-14f, -202f),
        //    new PointF(-3f, -250f),
        //    new PointF(-1f, -300f)
        //});

        //    path.AddLine(new PointF(-1f, -300f), new PointF(-1f, -330f));

        //    // <- center

        //    path.AddLine(new PointF(1f, -330f), new PointF(1f, -300f));

        //    path.AddCurve(new PointF[] {
        //    new PointF(1f, -300f),
        //    new PointF(3f, -250f),
        //    new PointF(14f, -202f),
        //    new PointF(15f, -195f)
        //});

        //    path.AddArc(new RectangleF(-15f, -210f, 30f, 30f), 0f, 90f);

        //    path.AddCurve(new PointF[] {
        //    new PointF(3f, -180f),
        //    new PointF(5f, -175f),
        //    new PointF(10f, -170f)
        //});

        //    path.AddCurve(new PointF[] {
        //    new PointF(10, -170),
        //    new PointF(2, -110),
        //    new PointF(12, -58),
        //    new PointF(12, -52)
        //});

        //    path.AddArc(new RectangleF(-12f, -64f, 24f, 24f), 0f, 90f);

        //    path.AddCurve(new PointF[] {
        //    new PointF(2f, -40f),
        //    new PointF(4f, -22f),
        //    new PointF(8f, -16f)
        //});

        //    path.AddCurve(new PointF[] {
        //    new PointF(8f, -16f),
        //    new PointF(4f,-12f),
        //    new PointF(10f * (float)Math.Cos(Math.PI / 3f), -10f * (float)Math.Sin(Math.PI / 3f))
        //});
        //}

        private float height;
        public float Height
        {
            get { return height; }
            set
            {
                height = value;
                Calculate();
                OnChanged(EventArgs.Empty);
            }
        }

        private float tailLength;
        public float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                Calculate();
                OnChanged(EventArgs.Empty);
            }
        }

        public override void Draw(Graphics g)
        {
            Matrix initialMatrix = g.Transform;

            float scaleFactor = height / 280f;
            g.ScaleTransform(scaleFactor, scaleFactor);

            base.Draw(g);

            g.Transform = initialMatrix;
        }
    }
}
