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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DustInTheWind.Clock.TimeProviders;
using DustInTheWind.Clock.Shapes;
using DustInTheWind.Clock.Demo.Properties;
using DustInTheWind.Clock.Shapes.Default;

namespace DustInTheWind.Clock.Demo
{
    public partial class FormExamples : Form
    {
        public FormExamples()
        {
            InitializeComponent();

            analogClockLocal.TimeProvider = new LocalTimeProvider();
            analogClockUTC.TimeProvider = new UtcTimeProvider();
            analogClockNewYork.TimeProvider = new UtcOffsetTimeProvider(TimeSpan.FromHours(-5));
            analogClockTokyo.TimeProvider = new UtcOffsetTimeProvider(TimeSpan.FromHours(9));
            analogClockHongKong.TimeProvider = new UtcOffsetTimeProvider(TimeSpan.FromHours(8));
            analogClockIndia.TimeProvider = new UtcOffsetTimeProvider(new TimeSpan(5, 30, 0));

            ImageHand hourHandShape = new ImageHand(Resources.hour_hand);
            hourHandShape.Height = 80;
            hourHandShape.Origin = new PointF(32f, 155.5f);
            analogClockImages.HourHandShape = hourHandShape;

            ImageHand minuteHandShape = new ImageHand(Resources.minute_hand);
            minuteHandShape.Height = 110;
            minuteHandShape.Origin = new PointF(14.5f, 206f);
            analogClockImages.MinuteHandShape = minuteHandShape;

            analogClock5.SweepHandShape = new DustInTheWind.Clock.Shapes.Fancy.SweepHandShape();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
