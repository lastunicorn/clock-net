// ClockNet
// Copyright (C) 2010 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using DustInTheWind.ClockNet.Shapes;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Provides a user interface that can edit most types of collections at design
    /// time and offeres additional support for collections containing items of types
    /// <see cref="IAngularShape"/>, <see cref="IHandShape"/> and <see cref="IGroundShape"/>.
    /// </summary>
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
                string interfaceName = typeof(IAngularShape).FullName;

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract &&
                        type.GetInterface(interfaceName) != null)
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
                string interfaceName = typeof(IHandShape).FullName;

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract &&
                        type.GetInterface(interfaceName) != null)
                    {
                        types.Add(type);
                    }
                }

                return types.ToArray();
            }
            else if (CollectionItemType.Equals(typeof(IGroundShape)))
            {
                List<Type> types = new List<Type>();

                Assembly assembly = Assembly.GetExecutingAssembly();
                string interfaceName = typeof(IGroundShape).FullName;

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract &&
                        type.GetInterface(interfaceName) != null)
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
