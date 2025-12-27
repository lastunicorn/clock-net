using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class HandsEditor : UserControl
    {
        private AnalogClock analogClock;

        public AnalogClock AnalogClock
        {
            get => analogClock;
            set
            {
                if (analogClock != null)
                {
                    analogClock.HandShapeAdded -= analogClockDemo_HandAdded;
                    analogClock.HandShapeRemoved -= analogClockDemo_HandRemoved;
                    analogClock.HandShapeCleared -= analogClockDemo_HandsCleared;

                    listBoxHands.Items.Clear();
                }

                analogClock = value;

                if (analogClock != null)
                {
                    analogClock.HandShapeAdded += analogClockDemo_HandAdded;
                    analogClock.HandShapeRemoved += analogClockDemo_HandRemoved;
                    analogClock.HandShapeCleared += analogClockDemo_HandsCleared;

                    foreach (IHand hand in analogClock.Hands)
                        listBoxHands.Items.Add(hand);
                }
            }
        }

        public HandsEditor()
        {
            InitializeComponent();

            Type[] hands = GetAllHands();
            listBoxHandsAvailable.Items.AddRange(hands);
        }

        private static Type[] GetAllHands()
        {
            Type handInterface = typeof(IHand);

            List<Type> handTypes = new List<Type>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    Type[] types = assembly.GetTypes();

                    IEnumerable<Type> hands = types
                        .Where(x => handInterface.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

                    handTypes.AddRange(hands);
                }
                catch (ReflectionTypeLoadException)
                {
                    // Skip assemblies that cannot be loaded
                }
            }

            return handTypes.ToArray();
        }

        private void listBoxHands_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = listBoxHands.SelectedItem;
        }

        private void buttonAddHand_Click(object sender, EventArgs e)
        {
            if (listBoxHandsAvailable.SelectedItem != null)
            {
                Type handType = (Type)listBoxHandsAvailable.SelectedItem;

                AddHand(handType);
            }
        }

        private void listBoxHandsAvailable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxHandsAvailable.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Type handType = (Type)listBoxHandsAvailable.Items[index];
                AddHand(handType);
            }
        }

        private void AddHand(Type handType)
        {
            ConstructorInfo ctor = handType.GetConstructor(new Type[0]);
            IHand shape = (IHand)ctor.Invoke(null);
            analogClock.Hands.Add(shape);
        }

        private void buttonRemoveHand_Click(object sender, EventArgs e)
        {
            if (listBoxHands.SelectedItem != null)
            {
                IHand handToRemove = listBoxHands.SelectedItem as IHand;
                analogClock.Hands.Remove(handToRemove);
            }
        }

        private void listBoxHands_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxHands.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                IHand handToRemove = (IHand)listBoxHands.Items[index];
                analogClock.Hands.Remove(handToRemove);
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (listBoxHands.SelectedIndex > 0)
            {
                int index = listBoxHands.SelectedIndex;
                IHand shape = listBoxHands.SelectedItem as IHand;
                if (shape != null)
                {
                    analogClock.Hands.RemoveAt(index);
                    analogClock.Hands.Insert(index - 1, shape);
                    listBoxHands.SelectedItem = shape;
                }
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (listBoxHands.SelectedIndex >= 0 && listBoxHands.SelectedIndex < listBoxHands.Items.Count - 1)
            {
                int index = listBoxHands.SelectedIndex;
                IHand shape = listBoxHands.SelectedItem as IHand;
                if (shape != null)
                {
                    analogClock.Hands.RemoveAt(index);
                    analogClock.Hands.Insert(index + 1, shape);
                    listBoxHands.SelectedItem = shape;
                }
            }
        }

        private void analogClockDemo_HandAdded(object sender, ShapeAddedEventArgs e)
        {
            listBoxHands.Items.Insert(e.Index, e.Shape);
        }

        private void analogClockDemo_HandRemoved(object sender, ShapeRemovedEventArgs e)
        {
            listBoxHands.Items.Remove(e.Shape);
        }

        private void analogClockDemo_HandsCleared(object sender, EventArgs e)
        {
            listBoxHands.Items.Clear();
        }
    }
}
