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

namespace DustInTheWind.Clock
{
    partial class AnalogClock
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();

                //if (textBrush != null)
                //    textBrush.Dispose();

                if (hourHandShape != null)
                    hourHandShape.Dispose();

                if (minuteHandShape != null)
                    minuteHandShape.Dispose();

                if (sweepHandShape != null)
                    sweepHandShape.Dispose();

                if (pinShape != null)
                    pinShape.Dispose();

                if (ticks1Shape != null)
                    ticks1Shape.Dispose();

                if (ticks5Shape != null)
                    ticks5Shape.Dispose();

                if (numbersShape != null)
                    numbersShape.Dispose();

                if (textShape != null)
                    textShape.Dispose();

                //if (hourHandShape != null && hourHandShape != defaultHourHandShape)
                //    hourHandShape.Dispose();

                //if (minuteHandShape != null && minuteHandShape != defaultMinuteHandShape)
                //    minuteHandShape.Dispose();

                //if (sweepHandShape != null && sweepHandShape != defaultSweepHandShape)
                //    sweepHandShape.Dispose();

                //if (pinShape != null && pinShape != defaultPinShape)
                //    pinShape.Dispose();

                //if (ticks1Shape != null && ticks1Shape != defaultTicks1Shape)
                //    ticks1Shape.Dispose();

                //if (ticks5Shape != null && ticks5Shape != defaultTicks5Shape)
                //    ticks5Shape.Dispose();

                //if (numbersShape != null && numbersShape != defaultNumbersShape)
                //    numbersShape.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components;
    }
}