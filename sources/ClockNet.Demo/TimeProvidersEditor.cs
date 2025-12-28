using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core.Shapes;
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


            Type[] timeProviderTypes = AppDomain.CurrentDomain.GetTypesImplementing<ITimeProvider>()
                .ToArray();

            comboBoxTimeProviders.Items.AddRange(timeProviderTypes);
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
            comboBoxTimeProviders.SelectedItem = analogClock.TimeProvider.GetType();
            propertyGridTimeProvider.SelectedObject = analogClock.TimeProvider;
        }
    }
}
