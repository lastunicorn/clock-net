using System;
using System.Windows.Forms;

namespace DustInTheWind.ClockNet.Core.Performace
{
    public partial class PerformanceView : UserControl
    {
        private PerformanceMeter performanceMeter;

        public PerformanceMeter PerformanceMeter
        {
            get => performanceMeter;
            set
            {
                if (performanceMeter != null)
                    performanceMeter.Changed -= HandlePerformanceChanged;

                performanceMeter = value;

                if (performanceMeter != null)
                    performanceMeter.Changed += HandlePerformanceChanged;
            }
        }

        private void HandlePerformanceChanged(object sender, EventArgs e)
        {
            UpdatePerformanceData();
        }

        private void UpdatePerformanceData()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdatePerformanceData()));
            }
            else
            {
                labelAverage.Text = $"{performanceMeter?.AverageTime.TotalMilliseconds:F4} ms";
                labelCurrent.Text = $"{performanceMeter?.LastTime.TotalMilliseconds:F4} ms";
                labelCount.Text = performanceMeter?.MeasurementCount.ToString();
            }
        }

        public PerformanceView()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            PerformanceMeter?.Reset();
        }
    }
}
