using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using DustInTheWind.Clock.Shapes;
using System.Reflection;

namespace DustInTheWind.Clock
{
    public class HandShapeCollectionEditor : CollectionEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HandShapeCollectionEditor"/> class.
        /// </summary>
        /// <param name="type">The type of the collection that will be edited.</param>
        public HandShapeCollectionEditor(Type type)
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
                    type.GetInterface(typeof(IHandShape).FullName) != null)
                {
                    types.Add(type);
                }
            }

            return types.ToArray();
        }
    }
}
