/////////////////////////////////////////////////////////////////////////////////////////////
//// Author: Vladimir Yangurskiy                                                         ////
/////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Drawing;

namespace TTRider.UI
{
    /// <summary>
    /// Provides Round-trip conversion from RGB to HSB and back
    /// </summary>
    public struct HsbColor
    {
        float h;
        float s;
        float b;
        int a;

        public HsbColor(float h, float s, float b)
        {
            this.a = 0xff;
            this.h = Math.Min(Math.Max(h, 0), 255);
            this.s = Math.Min(Math.Max(s, 0), 255);
            this.b = Math.Min(Math.Max(b, 0), 255);
        }

        public HsbColor(int a, float h, float s, float b)
        {
            this.a = a;
            this.h = Math.Min(Math.Max(h, 0), 255);
            this.s = Math.Min(Math.Max(s, 0), 255);
            this.b = Math.Min(Math.Max(b, 0), 255);
        }

        public HsbColor(Color color)
        {
            HsbColor temp = FromColor(color);
            this.a = temp.a;
            this.h = temp.h;
            this.s = temp.s;
            this.b = temp.b;
        }

        /// <summary>
        /// Hue
        /// </summary>
        public float H => h;

        /// <summary>
        /// Saturation
        /// </summary>
        public float S => s;

        /// <summary>
        /// Brightness
        /// </summary>
        public float B => b;

        /// <summary>
        /// Alpha
        /// </summary>
        public int A => a;

        public Color Color => FromHsb(this);

        public static Color ShiftHue(Color color, float hueDelta)
        {
            HsbColor hsb = FromColor(color);
            hsb.h += hueDelta;
            hsb.h = Math.Min(Math.Max(hsb.h, 0), 255);
            return FromHsb(hsb);
        }

        public static Color ShiftSaturation(Color color, float saturationDelta)
        {
            HsbColor hsb = FromColor(color);
            hsb.s += saturationDelta;
            hsb.s = Math.Min(Math.Max(hsb.s, 0), 255);
            return FromHsb(hsb);
        }


        public static Color ShiftBrighness(Color color, float brightnessDelta)
        {
            HsbColor hsb = HsbColor.FromColor(color);
            hsb.b += brightnessDelta;
            hsb.b = Math.Min(Math.Max(hsb.b, 0), 255);
            return FromHsb(hsb);
        }

        public static Color FromHsb(HsbColor hsbColor)
        {
            float r = hsbColor.b;
            float g = hsbColor.b;
            float b = hsbColor.b;

            if (hsbColor.s != 0)
            {
                float max = hsbColor.b;
                float dif = hsbColor.b * hsbColor.s / 255f;
                float min = hsbColor.b - dif;

                float h = hsbColor.h * 360f / 255f;

                if (h < 60f)
                {
                    r = max;
                    g = h * dif / 60f + min;
                    b = min;
                }
                else if (h < 120f)
                {
                    r = -(h - 120f) * dif / 60f + min;
                    g = max;
                    b = min;
                }
                else if (h < 180f)
                {
                    r = min;
                    g = max;
                    b = (h - 120f) * dif / 60f + min;
                }
                else if (h < 240f)
                {
                    r = min;
                    g = -(h - 240f) * dif / 60f + min;
                    b = max;
                }
                else if (h < 300f)
                {
                    r = (h - 240f) * dif / 60f + min;
                    g = min;
                    b = max;
                }
                else if (h <= 360f)
                {
                    r = max;
                    g = min;
                    b = -(h - 360f) * dif / 60 + min;
                }
                else
                {
                    r = 0;
                    g = 0;
                    b = 0;
                }
            }

            int alpha = hsbColor.a;
            int red = (int)Math.Round(Math.Min(Math.Max(r, 0), 255));
            int green = (int)Math.Round(Math.Min(Math.Max(g, 0), 255));
            int blue = (int)Math.Round(Math.Min(Math.Max(b, 0), 255));

            return Color.FromArgb(alpha, red, green, blue);
        }

        public static HsbColor FromColor(Color color)
        {
            HsbColor hsbColor = new HsbColor(0f, 0f, 0f)
            {
                a = color.A
            };

            float r = color.R;
            float g = color.G;
            float b = color.B;

            float max = Math.Max(r, Math.Max(g, b));

            if (max <= 0)
            {
                return hsbColor;
            }

            float min = Math.Min(r, Math.Min(g, b));
            float dif = max - min;

            if (max > min)
            {
                if (g == max)
                {
                    hsbColor.h = (b - r) / dif * 60f + 120f;
                }
                else if (b == max)
                {
                    hsbColor.h = (r - g) / dif * 60f + 240f;
                }
                else if (b > g)
                {
                    hsbColor.h = (g - b) / dif * 60f + 360f;
                }
                else
                {
                    hsbColor.h = (g - b) / dif * 60f;
                }
                if (hsbColor.h < 0)
                {
                    hsbColor.h = hsbColor.h + 360f;
                }
            }
            else
            {
                hsbColor.h = 0;
            }

            hsbColor.h *= 255f / 360f;
            hsbColor.s = (dif / max) * 255f;
            hsbColor.b = max;

            return hsbColor;
        }
    }
}
