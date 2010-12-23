using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using DustInTheWind.Clock.Shapes.Default;
using DustInTheWind.Clock.Shapes.Fancy;
using System.Reflection;
using DustInTheWind.Clock.Shapes;

namespace DustInTheWind.Clock
{
    public class BackgroundShapeCollectionEditor : CollectionEditor
    {
        public BackgroundShapeCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type[] CreateNewItemTypes()
        {
            List<Type> types = new List<Type>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            string interfaceName = typeof(IShape).FullName;

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract &&
                    type.GetInterface(interfaceName) != null &&
                    type.GetInterface(typeof(IAngularShape).FullName) == null &&
                    type.GetInterface(typeof(IHandShape).FullName) == null)
                {
                    types.Add(type);
                }
            }

            return types.ToArray();
        }
    }
}
