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
using System.Collections.ObjectModel;
using System.ComponentModel;
using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet
{
    public class ShapeCollection<T> : Collection<T>
        where T : IShape
    {

        #region Event ShapeAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="ShapeCollection{T}"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is added to the collection.")]
        public event EventHandler<ShapeAddedEventArgs> ShapeAdded;

        /// <summary>
        /// Raises the <see cref="ShapeAdded"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnShapeAdded(ShapeAddedEventArgs e)
        {
            ShapeAdded?.Invoke(this, e);
        }

        #endregion

        #region Event ShapeRemoved

        /// <summary>
        /// Event raised when a Shape is removed from the <see cref="ShapeCollection{T}"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is removed from the collection.")]
        public event EventHandler<ShapeRemovedEventArgs> ShapeRemoved;

        /// <summary>
        /// Raises the <see cref="ShapeRemoved"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnShapeRemoved(ShapeRemovedEventArgs e)
        {
            ShapeRemoved?.Invoke(this, e);
        }

        #endregion

        #region Event ShapeClear

        /// <summary>
        /// Event raised when the collection is cleared (all the shapes are removed).
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the BackgroundShapes collection is cleared (all the shapes are removed).")]
        public event EventHandler Cleared;

        /// <summary>
        /// Raises the <see cref="BackgroundShapeClear"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnCleared(EventArgs e)
        {
            Cleared?.Invoke(this, e);
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeCollection"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public ShapeCollection()
        {
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);

            OnShapeAdded(new ShapeAddedEventArgs(index, item));
        }

        protected override void RemoveItem(int index)
        {
            T item = this[index];

            base.RemoveItem(index);

            OnShapeRemoved(new ShapeRemovedEventArgs(item));
        }

        protected override void SetItem(int index, T item)
        {
            T oldItem = this[index];

            base.SetItem(index, item);

            OnShapeRemoved(new ShapeRemovedEventArgs(oldItem));
            OnShapeAdded(new ShapeAddedEventArgs(index, item));
        }

        protected override void ClearItems()
        {
            base.ClearItems();

            OnCleared(EventArgs.Empty);
        }
    }
}
