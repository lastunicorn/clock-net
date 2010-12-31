using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using DustInTheWind.Clock.Shapes;
using System.Reflection;

namespace DustInTheWind.Clock
{
    public class ShapeCollectionEditor : CollectionEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeCollectionEditor"/> class.
        /// </summary>
        /// <param name="type">The type of the collection that will be edited.</param>
        public ShapeCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type[] CreateNewItemTypes()
        {
            if (CollectionItemType == null)
            {
                return new Type[0];
            }
            else if (CollectionItemType.Equals(typeof(IAngularShape)))
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
            else if (CollectionItemType.Equals(typeof(IHandShape)))
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
            else if (CollectionItemType.Equals(typeof(IShape)))
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
            else
            {
                return new Type[0];
            }
        }
    }
}
