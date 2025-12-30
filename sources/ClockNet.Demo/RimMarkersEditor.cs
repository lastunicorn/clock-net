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
    public partial class RimMarkersEditor : UserControl
    {
        private AnalogClock analogClock;

        public AnalogClock AnalogClock
        {
            get => analogClock;
            set
            {
                if (analogClock != null)
                {
                    analogClock.RimMarkerAdded -= analogClockDemo_RimMarkerAdded;
                    analogClock.RimMarkerRemoved -= analogClockDemo_RimMarkerRemoved;
                    analogClock.RimMarkersCleared -= analogClockDemo_RimMarkersCleared;

                    listBoxRimMarkers.Items.Clear();
                }

                analogClock = value;

                if (analogClock != null)
                {
                    analogClock.RimMarkerAdded += analogClockDemo_RimMarkerAdded;
                    analogClock.RimMarkerRemoved += analogClockDemo_RimMarkerRemoved;
                    analogClock.RimMarkersCleared += analogClockDemo_RimMarkersCleared;

                    foreach (IRimMarker rimMarker in analogClock.RimMarkers)
                        listBoxRimMarkers.Items.Add(rimMarker);
                }
            }
        }

        public RimMarkersEditor()
        {
            InitializeComponent();

            Type[] hands = AppDomain.CurrentDomain.GetTypesImplementing<IRimMarker>()
                .ToArray();

            listBoxRimMarkersAvailable.Items.AddRange(hands);
        }

        private void listBoxRimMarkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridAngularShapes.SelectedObject = listBoxRimMarkers.SelectedItem;
        }

        private void buttonAddRimMarker_Click(object sender, EventArgs e)
        {
            if (listBoxRimMarkersAvailable.SelectedItem != null)
            {
                Type rimMarkerType = (Type)listBoxRimMarkersAvailable.SelectedItem;

                AddRimMarker(rimMarkerType);
            }
        }

        private void listBoxRimMarkersAvailable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxRimMarkersAvailable.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Type rimMarkerType = (Type)listBoxRimMarkersAvailable.Items[index];
                AddRimMarker(rimMarkerType);
            }
        }

        private void AddRimMarker(Type rimMarkerType)
        {
            ConstructorInfo ctor = rimMarkerType.GetConstructor(new Type[0]);
            IRimMarker shape = (IRimMarker)ctor.Invoke(null);
            analogClock.RimMarkers.Add(shape);
        }

        private void buttonRemoveRimMarker_Click(object sender, EventArgs e)
        {
            if (listBoxRimMarkers.SelectedItem != null)
            {
                IRimMarker rimMarkerToRemove = listBoxRimMarkers.SelectedItem as IRimMarker;
                analogClock.RimMarkers.Remove(rimMarkerToRemove);
            }
        }

        private void listBoxRimMarkers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxRimMarkers.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                IRimMarker rimMarkerToRemove = (IRimMarker)listBoxRimMarkers.Items[index];
                analogClock.RimMarkers.Remove(rimMarkerToRemove);
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (listBoxRimMarkers.SelectedIndex > 0)
            {
                int index = listBoxRimMarkers.SelectedIndex;
                IRimMarker shape = listBoxRimMarkers.SelectedItem as IRimMarker;
                if (shape != null)
                {
                    analogClock.RimMarkers.RemoveAt(index);
                    analogClock.RimMarkers.Insert(index - 1, shape);
                    listBoxRimMarkers.SelectedItem = shape;
                }
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (listBoxRimMarkers.SelectedIndex >= 0 && listBoxRimMarkers.SelectedIndex < listBoxRimMarkers.Items.Count - 1)
            {
                int index = listBoxRimMarkers.SelectedIndex;
                IRimMarker shape = listBoxRimMarkers.SelectedItem as IRimMarker;
                if (shape != null)
                {
                    analogClock.RimMarkers.RemoveAt(index);
                    analogClock.RimMarkers.Insert(index + 1, shape);
                    listBoxRimMarkers.SelectedItem = shape;
                }
            }
        }

        private void analogClockDemo_RimMarkerAdded(object sender, ShapeAddedEventArgs e)
        {
            listBoxRimMarkers.Items.Insert(e.Index, e.Shape);
        }

        private void analogClockDemo_RimMarkerRemoved(object sender, ShapeRemovedEventArgs e)
        {
            listBoxRimMarkers.Items.Remove(e.Shape);
        }

        private void analogClockDemo_RimMarkersCleared(object sender, EventArgs e)
        {
            listBoxRimMarkers.Items.Clear();
        }
    }
}
