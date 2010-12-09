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
using System.Drawing;
using System.Windows.Forms;
using DustInTheWind.Clock.Shapes;
using DustInTheWind.Clock.TimeProviders;

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

            analogClockImages.SetShapes(ShapeSet.ImageShapes);
            analogClock1.SetShapes(ShapeSet.BlackDot);
            analogClock5.SetShapes(ShapeSet.Fancy);
            analogClock7.SetShapes(ShapeSet.WhiteFancy);
        }
    }
}
