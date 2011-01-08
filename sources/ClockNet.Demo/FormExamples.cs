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
using System.Windows.Forms;
using DustInTheWind.ClockNet.Compass;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class FormExamples : Form
    {
        public FormExamples()
        {
            InitializeComponent();
            RefreshCompass();
        }

        private void numericUpDownDegrees_ValueChanged(object sender, EventArgs e)
        {
            RefreshCompass();
        }

        private void numericUpDownMinutes_ValueChanged(object sender, EventArgs e)
        {
            RefreshCompass();
        }

        private void numericUpDownSeconds_ValueChanged(object sender, EventArgs e)
        {
            RefreshCompass();
        }

        private void RefreshCompass()
        {
            int degrees = (int)numericUpDownDegrees.Value;
            int minutes = (int)numericUpDownMinutes.Value;
            int seconds = (int)numericUpDownSeconds.Value;

            CompassDirection direction = CompassDirection.FromAzimuth(degrees, minutes, seconds);

            analogClockCompass.Time = direction.ToTimeSpan();
        }

        private void FormExamples_Load(object sender, EventArgs e)
        {
            Random rand = new Random();

            numericUpDownDegrees.Value = rand.Next(360);
            numericUpDownMinutes.Value = rand.Next(60);
            numericUpDownSeconds.Value = rand.Next(60);
        }

        private void buttonNorth_Click(object sender, EventArgs e)
        {
            numericUpDownDegrees.Value = 0;
            numericUpDownMinutes.Value = 0;
            numericUpDownSeconds.Value = 0;
        }

        private void buttonEast_Click(object sender, EventArgs e)
        {
            numericUpDownDegrees.Value = 90;
            numericUpDownMinutes.Value = 0;
            numericUpDownSeconds.Value = 0;
        }

        private void buttonSouth_Click(object sender, EventArgs e)
        {
            numericUpDownDegrees.Value = 180;
            numericUpDownMinutes.Value = 0;
            numericUpDownSeconds.Value = 0;
        }

        private void buttonWest_Click(object sender, EventArgs e)
        {
            numericUpDownDegrees.Value = 270;
            numericUpDownMinutes.Value = 0;
            numericUpDownSeconds.Value = 0;
        }
    }
}
