using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core;
using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class ShapesEditor : UserControl
    {
        private AnalogClock analogClock;

        public AnalogClock AnalogClock
        {
            get => analogClock;
            set
            {
                if (analogClock != null)
                {
                    analogClock.ShapeAdded -= analogClockDemo_ShapeAdded;
                    analogClock.ShapeRemoved -= analogClockDemo_ShapeRemoved;
                    analogClock.ShapesCleared -= analogClockDemo_ShapesCleared;

                    foreach (IShape shape in listBoxShapes.Items)
                    {
                        shape.NameChanged -= HandleShapeNameChanged;
                    }

                    listBoxShapes.Items.Clear();
                }

                analogClock = value;

                if (analogClock != null)
                {
                    analogClock.ShapeAdded += analogClockDemo_ShapeAdded;
                    analogClock.ShapeRemoved += analogClockDemo_ShapeRemoved;
                    analogClock.ShapesCleared += analogClockDemo_ShapesCleared;

                    foreach (IShape shape in analogClock.Shapes)
                    {
                        listBoxShapes.Items.Add(shape);
                        shape.NameChanged += HandleShapeNameChanged;
                    }
                }
            }
        }

        public ShapesEditor()
        {
            InitializeComponent();

            Type[] shapeTypes = AppDomain.CurrentDomain.GetTypesImplementing<IShape>()
                .ToArray();

            listBoxAvailableShapes.Items.AddRange(shapeTypes);
        }

        private void listBoxBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridShapes.SelectedObject = listBoxShapes.SelectedItem;
        }

        private void buttonAddBackground_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableShapes.SelectedItem != null)
            {
                Type backgroundType = (Type)listBoxAvailableShapes.SelectedItem;

                AddShape(backgroundType);
            }
        }

        private void listBoxBackgroundsAvailable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxAvailableShapes.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Type backgroundType = (Type)listBoxAvailableShapes.Items[index];
                AddShape(backgroundType);
            }
        }

        private void AddShape(Type shapeType)
        {
            ConstructorInfo ctor = shapeType.GetConstructor(new Type[0]);
            IShape shape = (IShape)ctor.Invoke(null);
            AnalogClock.Shapes.Add(shape);
            shape.NameChanged += HandleShapeNameChanged;
        }

        private void HandleShapeNameChanged(object sender, EventArgs e)
        {
            int itemIndex = listBoxShapes.Items.IndexOf(sender);

            if (itemIndex >= 0)
                listBoxShapes.Items[itemIndex] = sender;
        }

        private void buttonRemoveShape_Click(object sender, EventArgs e)
        {
            if (listBoxShapes.SelectedItem != null)
            {
                IShape shapeToRemove = listBoxShapes.SelectedItem as IShape;
                shapeToRemove.NameChanged -= HandleShapeNameChanged;
                AnalogClock.Shapes.Remove(shapeToRemove);
            }
        }

        private void listBoxShapes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxShapes.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                IShape shapeToRemove = (IShape)listBoxShapes.Items[index];
                shapeToRemove.NameChanged -= HandleShapeNameChanged;
                AnalogClock.Shapes.Remove(shapeToRemove);
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (listBoxShapes.SelectedIndex > 0)
            {
                int index = listBoxShapes.SelectedIndex;
                IShape shape = listBoxShapes.SelectedItem as IShape;
                if (shape != null)
                {
                    AnalogClock.Shapes.RemoveAt(index);
                    AnalogClock.Shapes.Insert(index - 1, shape);
                    listBoxShapes.SelectedItem = shape;
                }
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (listBoxShapes.SelectedIndex >= 0 && listBoxShapes.SelectedIndex < listBoxShapes.Items.Count - 1)
            {
                int index = listBoxShapes.SelectedIndex;
                IShape shape = listBoxShapes.SelectedItem as IShape;
                if (shape != null)
                {
                    AnalogClock.Shapes.RemoveAt(index);
                    AnalogClock.Shapes.Insert(index + 1, shape);
                    listBoxShapes.SelectedItem = shape;
                }
            }
        }

        private void analogClockDemo_ShapeAdded(object sender, ShapeAddedEventArgs e)
        {
            listBoxShapes.Items.Insert(e.Index, e.Shape);
        }

        private void analogClockDemo_ShapeRemoved(object sender, ShapeRemovedEventArgs e)
        {
            listBoxShapes.Items.Remove(e.Shape);
        }

        private void analogClockDemo_ShapesCleared(object sender, EventArgs e)
        {
            listBoxShapes.Items.Clear();
        }
    }
}
