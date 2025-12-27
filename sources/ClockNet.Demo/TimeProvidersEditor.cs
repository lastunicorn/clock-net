using System;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core.TimeProviders;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class TimeProvidersEditor : UserControl
    {
        private AnalogClock analogClock;

        public AnalogClock AnalogClock
        {
            get => analogClock;
            set
            {
                if (analogClock != null)
                {
                    analogClock.TimeProviderChanged -= analogClock_TimeProviderChanged;

                    comboBoxTimeProviders.SelectedIndex = 0;
                    propertyGridTimeProvider.SelectedObject = null;
                }

                analogClock = value;

                if (analogClock != null)
                {
                    analogClock.TimeProviderChanged += analogClock_TimeProviderChanged;

                    if (analogClock.TimeProvider == null)
                        comboBoxTimeProviders.SelectedIndex = 0;
                    else
                        comboBoxTimeProviders.SelectedItem = analogClock.TimeProvider.GetType();

                    propertyGridTimeProvider.SelectedObject = analogClock.TimeProvider == null
                        ? null
                        : analogClock.TimeProvider;
                }
            }
        }

        public TimeProvidersEditor()
        {
            InitializeComponent();

            comboBoxTimeProviders.Items.Add("(none)");
            comboBoxTimeProviders.Items.Add(typeof(LocalTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(UtcTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(BrokenTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(RandomTimeProvider));
        }

        private void comboBoxTimeProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimeProviders.SelectedItem == null || comboBoxTimeProviders.SelectedItem.Equals("(none)"))
            {
                analogClock.TimeProvider = null;
            }
            else
            {
                Type type = (Type)comboBoxTimeProviders.SelectedItem;

                ConstructorInfo constructorInfo = type.GetConstructor(new Type[0]);
                ITimeProvider timeProvider = (ITimeProvider)constructorInfo.Invoke(null);
                analogClock.TimeProvider = timeProvider;
            }
        }

        private void analogClock_TimeProviderChanged(object sender, EventArgs e)
        {
            propertyGridTimeProvider.SelectedObject = analogClock.TimeProvider;
        }
    }
}
