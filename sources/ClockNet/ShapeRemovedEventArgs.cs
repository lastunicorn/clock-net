using System;
using DustInTheWind.Clock.Shapes;

namespace DustInTheWind.Clock
{
    public class ShapeRemovedEventArgs : EventArgs
    {
        public ShapeRemovedEventArgs(IShape shape)
        {

        }
    }
}
