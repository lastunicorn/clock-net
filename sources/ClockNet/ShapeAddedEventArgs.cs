using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
