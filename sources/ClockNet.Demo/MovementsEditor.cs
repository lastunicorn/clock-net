using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core;
using DustInTheWind.ClockNet.Core.Movements;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class MovementsEditor : UserControl
    {
        private AnalogClock analogClock;

        public AnalogClock AnalogClock
        {
            get => analogClock;
            set
            {
                if (analogClock != null)
                {
                    analogClock.MovementChanged -= analogClock_MovementChanged;

                    comboBoxMovements.SelectedIndex = 0;
                    propertyGridMovement.SelectedObject = null;
                }

                analogClock = value;

                if (analogClock != null)
                {
                    analogClock.MovementChanged += analogClock_MovementChanged;

                    if (analogClock.Movement == null)
                        comboBoxMovements.SelectedIndex = 0;
                    else
                        comboBoxMovements.SelectedItem = analogClock.Movement.GetType();

                    propertyGridMovement.SelectedObject = analogClock.Movement == null
                        ? null
                        : analogClock.Movement;
                }
            }
        }

        public MovementsEditor()
        {
            InitializeComponent();

            comboBoxMovements.Items.Add("(none)");


            Type[] movementTypes = AppDomain.CurrentDomain.GetTypesImplementing<IMovement>()
                .ToArray();

            comboBoxMovements.Items.AddRange(movementTypes);
        }

        private void comboBoxMovements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMovements.SelectedItem == null || comboBoxMovements.SelectedItem.Equals("(none)"))
            {
                analogClock.Movement = null;
            }
            else
            {
                Type type = (Type)comboBoxMovements.SelectedItem;

                ConstructorInfo constructorInfo = type.GetConstructor(new Type[0]);
                IMovement movement = (IMovement)constructorInfo.Invoke(null);
                analogClock.Movement = movement;
            }
        }

        private void analogClock_MovementChanged(object sender, EventArgs e)
        {
            if (analogClock.Movement == null)
                comboBoxMovements.SelectedIndex = 0;
            else
                comboBoxMovements.SelectedItem = analogClock.Movement.GetType();

            propertyGridMovement.SelectedObject = analogClock.Movement;
        }
    }
}
