using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DustInTheWind.ClockNet.Compass
{
    public struct CompassDirection
    {
        // 12 h = 720 min = 43.200 ses = 43.200.000 ms = 432.000.000.000 ticks
        // 360 d = 21.600 m = 1.296.000 s

        public const int SecondsPerMinute = 60;
        public const int SecondsPerDegree = 3600;
        public const int SecondsPerCompass = 1296000;
        public const int SecondsPerEmisfere = 648000;
        public const int SecondsPerQuadrant = 324000;
        public const int MinutesPerDegree = 60;
        public const int MinutesPerCompass = 21600;
        public const int DegreesPerCompass = 360;

        public const double TimeTicksPerSecond = 1000000 / 3;

        private int seconds;

        public int Degrees
        {
            get { return seconds / SecondsPerDegree; }
        }

        public int Minutes
        {
            get { return (seconds % SecondsPerDegree) / SecondsPerMinute; }
        }

        public int Seconds
        {
            get { return (seconds % SecondsPerDegree) % SecondsPerMinute; }
        }

        public float TotalDegrees
        {
            get { return (float)seconds / (float)SecondsPerDegree; }
        }

        public float TotalMinutes
        {
            get { return (float)seconds / (float)SecondsPerMinute; }
        }

        public int TotalSeconds
        {
            get { return seconds; }
        }

        public Quadrant Quadrant
        {
            get
            {
                if (this.seconds < 324000)
                    return Quadrant.NE;
                else if (this.seconds < 648000)
                    return Quadrant.SE;
                else if (this.seconds < 972000)
                    return Quadrant.SW;
                else
                    return Quadrant.NW;
            }
        }

        public int QuadrantDegrees
        {
            get
            {
                int seconds;

                if (this.seconds < 324000)
                    seconds = this.seconds;
                else if (this.seconds < 648000)
                    seconds = SecondsPerEmisfere - this.seconds;
                else if (this.seconds < 972000)
                    seconds = SecondsPerEmisfere + this.seconds;
                else
                    seconds = SecondsPerCompass - this.seconds;

                return seconds / SecondsPerDegree;
            }
        }

        public int QuadrantMinutes
        {
            get
            {
                int seconds;

                if (this.seconds < 324000)
                    seconds = this.seconds;
                else if (this.seconds < 648000)
                    seconds = SecondsPerEmisfere - this.seconds;
                else if (this.seconds < 972000)
                    seconds = SecondsPerEmisfere + this.seconds;
                else
                    seconds = SecondsPerCompass - this.seconds;

                return (seconds % SecondsPerDegree) / SecondsPerMinute;
            }
        }

        public int QuadrantSeconds
        {
            get
            {
                int seconds;

                if (this.seconds < 324000)
                    seconds = this.seconds;
                else if (this.seconds < 648000)
                    seconds = SecondsPerEmisfere - this.seconds;
                else if (this.seconds < 972000)
                    seconds = SecondsPerEmisfere + this.seconds;
                else
                    seconds = SecondsPerCompass - this.seconds;

                return (seconds % SecondsPerDegree) % SecondsPerMinute;
            }
        }


        public CompassDirection(int seconds)
        {
            this.seconds = seconds;
        }

        public static CompassDirection FromAzimuth(int degrees)
        {
            if (degrees < 0 || degrees >= 360)
                throw new ArgumentOutOfRangeException("degrees", "The degrees must be an integer number between 0 and 360.");

            return new CompassDirection(degrees * SecondsPerDegree);
        }

        public static CompassDirection FromAzimuth(int degrees, int minutes)
        {
            if (degrees < 0 || degrees >= 360)
                throw new ArgumentOutOfRangeException("degrees", "The degrees must be an integer number between 0 and 360.");

            if (minutes < 0 || minutes > 60)
                throw new ArgumentOutOfRangeException("minutes", "The minutes must be an integer number between 0 and 60.");

            return new CompassDirection(degrees * SecondsPerDegree + minutes * SecondsPerMinute);
        }

        public static CompassDirection FromAzimuth(int degrees, int minutes, int seconds)
        {
            if (degrees < 0 || degrees >= 360)
                throw new ArgumentOutOfRangeException("degrees", "The degrees must be an integer number between 0 and 360.");

            if (minutes < 0 || minutes > 60)
                throw new ArgumentOutOfRangeException("minutes", "The minutes must be an integer number between 0 and 60.");

            if (seconds < 0 || seconds > 60)
                throw new ArgumentOutOfRangeException("seconds", "The seconds must be an integer number between 0 and 60.");

            return new CompassDirection(degrees * SecondsPerDegree + minutes * SecondsPerMinute + seconds);
        }

        public static CompassDirection FromQuadrant(Quadrant quadrant, int degrees)
        {
            if (degrees < 0 || degrees > 90)
                throw new ArgumentOutOfRangeException("degrees", "The degrees must be an integer number between 0 and 90.");

            int quadrantSeconds = degrees * SecondsPerDegree;

            switch (quadrant)
            {
                case Quadrant.NE:
                    return new CompassDirection(quadrantSeconds);

                case Quadrant.SE:
                    return new CompassDirection(SecondsPerEmisfere - quadrantSeconds);

                case Quadrant.SW:
                    return new CompassDirection(SecondsPerEmisfere + quadrantSeconds);

                case Quadrant.NW:
                    return new CompassDirection(SecondsPerCompass - quadrantSeconds);

                default:
                    throw new ArgumentException("Invalid quadrant.", "quadrant");
            }
        }

        public static CompassDirection FromQuadrant(Quadrant quadrant, int degrees, int minutes)
        {
            if (degrees < 0 || degrees > 90)
                throw new ArgumentOutOfRangeException("degrees", "The degrees must be an integer number between 0 and 90.");

            if (minutes < 0 || minutes > 60)
                throw new ArgumentOutOfRangeException("minutes", "The minutes must be an integer number between 0 and 60.");

            int quadrantSeconds = degrees * SecondsPerDegree + minutes * SecondsPerMinute;

            switch (quadrant)
            {
                case Quadrant.NE:
                    return new CompassDirection(quadrantSeconds);

                case Quadrant.SE:
                    return new CompassDirection(SecondsPerEmisfere - quadrantSeconds);

                case Quadrant.SW:
                    return new CompassDirection(SecondsPerEmisfere + quadrantSeconds);

                case Quadrant.NW:
                    return new CompassDirection(SecondsPerCompass - quadrantSeconds);

                default:
                    throw new ArgumentException("Invalid quadrant.", "quadrant");
            }
        }

        public static CompassDirection FromQuadrant(Quadrant quadrant, int degrees, int minutes, int seconds)
        {
            if (degrees < 0 || degrees > 90)
                throw new ArgumentOutOfRangeException("degrees", "The degrees must be an integer number between 0 and 90.");

            if (minutes < 0 || minutes > 60)
                throw new ArgumentOutOfRangeException("minutes", "The minutes must be an integer number between 0 and 60.");

            if (seconds < 0 || seconds > 60)
                throw new ArgumentOutOfRangeException("seconds", "The seconds must be an integer number between 0 and 60.");

            int quadrantSeconds = degrees * SecondsPerDegree + minutes * SecondsPerMinute + seconds;

            switch (quadrant)
            {
                case Quadrant.NE:
                    return new CompassDirection(quadrantSeconds);

                case Quadrant.SE:
                    return new CompassDirection(SecondsPerEmisfere - quadrantSeconds);

                case Quadrant.SW:
                    return new CompassDirection(SecondsPerEmisfere + quadrantSeconds);

                case Quadrant.NW:
                    return new CompassDirection(SecondsPerCompass - quadrantSeconds);

                default:
                    throw new ArgumentException("Invalid quadrant.", "quadrant");
            }
        }

        private static CompassDirection empty = new CompassDirection(0);
        public static CompassDirection Empty
        {
            get { return empty; }
        }

        public static CompassDirection Parse(string value)
        {
            return empty;
        }

        public override string ToString()
        {
            return ToString(CompassDirectionFormat.Azimuth);
        }

        public string ToString(CompassDirectionFormat format)
        {
            switch (format)
            {
                default:
                case CompassDirectionFormat.Azimuth:
                    {
                        int degrees = Degrees;
                        int minutes = Minutes;
                        int seconds = Seconds;

                        StringBuilder sb = new StringBuilder();

                        if (degrees > 0)
                            sb.Append(degrees.ToString() + "d");

                        if (minutes > 0)
                            sb.Append(minutes.ToString() + "m");

                        if (seconds > 0)
                            sb.Append(seconds.ToString() + "s");

                        return sb.ToString();
                    }

                case CompassDirectionFormat.Quadrant:
                    {
                        if (this.seconds == 0) return "N";
                        if (this.seconds == 324000) return "E";
                        if (this.seconds == 648000) return "S";
                        if (this.seconds == 972000) return "W";

                        string first;
                        int seconds;
                        string last;

                        if (this.seconds < 324000)
                        {
                            // NE

                            first = "N";
                            last = "E";
                            seconds = this.seconds;
                        }
                        else if (this.seconds < 648000)
                        {
                            // SE

                            first = "S";
                            last = "E";
                            seconds = SecondsPerEmisfere - this.seconds;
                        }
                        else if (this.seconds < 972000)
                        {
                            // SW

                            first = "S";
                            last = "W";
                            seconds = SecondsPerEmisfere + this.seconds;
                        }
                        else
                        {
                            // NW

                            first = "N";
                            last = "W";
                            seconds = SecondsPerCompass - this.seconds;
                        }


                        int d = seconds / SecondsPerDegree;
                        int m = (seconds % SecondsPerDegree) / SecondsPerMinute;
                        int s = (seconds % SecondsPerDegree) % SecondsPerMinute;

                        StringBuilder sb = new StringBuilder();

                        sb.Append(first);

                        if (d > 0) sb.Append(d.ToString() + "d");

                        if (m > 0) sb.Append(m.ToString() + "m");

                        if (s > 0) sb.Append(s.ToString() + "s");

                        sb.Append(last);

                        return sb.ToString();
                    }
            }
        }

        /// <summary>
        /// The transformation is performed with precision loss.
        /// </summary>
        /// <returns></returns>
        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromTicks((long)Math.Round(seconds * TimeTicksPerSecond));
        }
    }
}
