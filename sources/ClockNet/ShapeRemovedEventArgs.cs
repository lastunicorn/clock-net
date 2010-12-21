using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
