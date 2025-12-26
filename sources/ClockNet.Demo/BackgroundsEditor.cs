using System;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class BackgroundsEditor : UserControl
    {
        private AnalogClock analogClock;

        public AnalogClock AnalogClock
        {
            get => analogClock;
            set
            {
                if (analogClock != null)
                {
                    analogClock.BackgroundAdded -= analogClockDemo_BackgroundsAdded;
                    analogClock.BackgroundRemoved -= analogClockDemo_BackgroundRemoved;
                    analogClock.BackgroundsCleared -= analogClockDemo_BackgroundsCleared;

                    listBoxBackgrounds.Items.Clear();
                }

                analogClock = value;

                if (analogClock != null)
                {
                    analogClock.BackgroundAdded += analogClockDemo_BackgroundsAdded;
                    analogClock.BackgroundRemoved += analogClockDemo_BackgroundRemoved;
                    analogClock.BackgroundsCleared += analogClockDemo_BackgroundsCleared;

                    foreach (IBackground background in analogClock.Backgrounds)
                        listBoxBackgrounds.Items.Add(background);
                }
            }
        }

        public BackgroundsEditor()
        {
            InitializeComponent();

            listBoxBackgroundsAvailable.Items.AddRange(new Type[] {
                typeof(LineBackground),
                typeof(PolygonBackground),
                typeof(RectangleBackground),
                typeof(EllipseBackground),
                typeof(PathBackground),
                typeof(StringBackground),
                typeof(ImageBackground),
                typeof(ClockBackground),
                typeof(FancyBackground)
            });
        }

        private void listBoxBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridBackgroundShapes.SelectedObject = listBoxBackgrounds.SelectedItem;
        }

        private void buttonAddBackground_Click(object sender, EventArgs e)
        {
            if (listBoxBackgroundsAvailable.SelectedItem != null)
            {
                Type backgroundType = (Type)listBoxBackgroundsAvailable.SelectedItem;

                AddBackground(backgroundType);
            }
        }

        private void listBoxBackgroundsAvailable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxBackgroundsAvailable.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Type backgroundType = (Type)listBoxBackgroundsAvailable.Items[index];
                AddBackground(backgroundType);
            }
        }

        private void AddBackground(Type backgroundType)
        {
            ConstructorInfo ctor = backgroundType.GetConstructor(new Type[0]);
            IBackground background = (IBackground)ctor.Invoke(null);
            AnalogClock.Backgrounds.Add(background);
        }

        private void buttonRemoveBackground_Click(object sender, EventArgs e)
        {
            if (listBoxBackgrounds.SelectedItem != null)
            {
                IBackground backgroundToRemove = listBoxBackgrounds.SelectedItem as IBackground;
                AnalogClock.Backgrounds.Remove(backgroundToRemove);
            }
        }

        private void listBoxBackgrounds_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxBackgrounds.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                IBackground backgroundToRemove = (IBackground)listBoxBackgrounds.Items[index];
                AnalogClock.Backgrounds.Remove(backgroundToRemove);
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (listBoxBackgrounds.SelectedIndex > 0)
            {
                int index = listBoxBackgrounds.SelectedIndex;
                IBackground shape = listBoxBackgrounds.SelectedItem as IBackground;
                if (shape != null)
                {
                    AnalogClock.Backgrounds.RemoveAt(index);
                    AnalogClock.Backgrounds.Insert(index - 1, shape);
                    listBoxBackgrounds.SelectedItem = shape;
                }
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (listBoxBackgrounds.SelectedIndex >= 0 && listBoxBackgrounds.SelectedIndex < listBoxBackgrounds.Items.Count - 1)
            {
                int index = listBoxBackgrounds.SelectedIndex;
                IBackground shape = listBoxBackgrounds.SelectedItem as IBackground;
                if (shape != null)
                {
                    AnalogClock.Backgrounds.RemoveAt(index);
                    AnalogClock.Backgrounds.Insert(index + 1, shape);
                    listBoxBackgrounds.SelectedItem = shape;
                }
            }
        }

        private void analogClockDemo_BackgroundsAdded(object sender, ShapeAddedEventArgs e)
        {
            listBoxBackgrounds.Items.Insert(e.Index, e.Shape);
        }

        private void analogClockDemo_BackgroundRemoved(object sender, ShapeRemovedEventArgs e)
        {
            listBoxBackgrounds.Items.Remove(e.Shape);
        }

        private void analogClockDemo_BackgroundsCleared(object sender, EventArgs e)
        {
            listBoxBackgrounds.Items.Clear();
        }
    }
}
