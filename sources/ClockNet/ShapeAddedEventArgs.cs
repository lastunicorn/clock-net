using System;
using DustInTheWind.Clock.Shapes;

namespace DustInTheWind.Clock
{
    public class ShapeAddedEventArgs : EventArgs
    {
        public ShapeAddedEventArgs(int index, IShape shape)
        {

        }
    }
}
