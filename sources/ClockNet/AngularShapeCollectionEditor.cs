using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using DustInTheWind.Clock.Shapes;
using System.Reflection;

namespace DustInTheWind.Clock
{
    public class AngularShapeCollectionEditor : CollectionEditor
    {
        public AngularShapeCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type[] CreateNewItemTypes()
        {
            List<Type> types = new List<Type>();

            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract &&
                    type.GetInterface(typeof(IAngularShape).FullName) != null)
                {
                    types.Add(type);
                }
            }

            return types.ToArray();
        }
    }
}
