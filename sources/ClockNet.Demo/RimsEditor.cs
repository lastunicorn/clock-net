using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class RimsEditor : UserControl
    {
        private AnalogClock analogClock;

        public AnalogClock AnalogClock
        {
            get => analogClock;
            set
            {
                if (analogClock != null)
                {
                    analogClock.RimAdded -= analogClockDemo_RimAdded;
                    analogClock.RimRemoved -= analogClockDemo_RimRemoved;
                    analogClock.RimsCleared -= analogClockDemo_RimsCleared;

                    listBoxRims.Items.Clear();
                }

                analogClock = value;

                if (analogClock != null)
                {
                    analogClock.RimAdded += analogClockDemo_RimAdded;
                    analogClock.RimRemoved += analogClockDemo_RimRemoved;
                    analogClock.RimsCleared += analogClockDemo_RimsCleared;

                    foreach (IRim rim in analogClock.Rims)
                        listBoxRims.Items.Add(rim);
                }
            }
        }

        public RimsEditor()
        {
            InitializeComponent();

            Type[] hands = AppDomain.CurrentDomain.GetTypesImplementing<IRim>()
                .ToArray();

            listBoxRimsAvailable.Items.AddRange(hands);
        }

        private void listBoxRims_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridRims.SelectedObject = listBoxRims.SelectedItem;
        }

        private void buttonAddRim_Click(object sender, EventArgs e)
        {
            if (listBoxRimsAvailable.SelectedItem != null)
            {
                Type rimType = (Type)listBoxRimsAvailable.SelectedItem;

                AddRim(rimType);
            }
        }

        private void listBoxRimsAvailable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxRimsAvailable.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Type rimType = (Type)listBoxRimsAvailable.Items[index];
                AddRim(rimType);
            }
        }

        private void AddRim(Type rimType)
        {
            ConstructorInfo ctor = rimType.GetConstructor(new Type[0]);
            IRim shape = (IRim)ctor.Invoke(null);
            analogClock.Rims.Add(shape);
        }

        private void buttonRemoveRim_Click(object sender, EventArgs e)
        {
            if (listBoxRims.SelectedItem != null)
            {
                IRim rimToRemove = listBoxRims.SelectedItem as IRim;
                analogClock.Rims.Remove(rimToRemove);
            }
        }

        private void listBoxRims_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxRims.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                IRim rimToRemove = (IRim)listBoxRims.Items[index];
                analogClock.Rims.Remove(rimToRemove);
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (listBoxRims.SelectedIndex > 0)
            {
                int index = listBoxRims.SelectedIndex;
                IRim shape = listBoxRims.SelectedItem as IRim;
                if (shape != null)
                {
                    analogClock.Rims.RemoveAt(index);
                    analogClock.Rims.Insert(index - 1, shape);
                    listBoxRims.SelectedItem = shape;
                }
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (listBoxRims.SelectedIndex >= 0 && listBoxRims.SelectedIndex < listBoxRims.Items.Count - 1)
            {
                int index = listBoxRims.SelectedIndex;
                IRim shape = listBoxRims.SelectedItem as IRim;
                if (shape != null)
                {
                    analogClock.Rims.RemoveAt(index);
                    analogClock.Rims.Insert(index + 1, shape);
                    listBoxRims.SelectedItem = shape;
                }
            }
        }

        private void analogClockDemo_RimAdded(object sender, ShapeAddedEventArgs e)
        {
            listBoxRims.Items.Insert(e.Index, e.Shape);
        }

        private void analogClockDemo_RimRemoved(object sender, ShapeRemovedEventArgs e)
        {
            listBoxRims.Items.Remove(e.Shape);
        }

        private void analogClockDemo_RimsCleared(object sender, EventArgs e)
        {
            listBoxRims.Items.Clear();
        }
    }
}
