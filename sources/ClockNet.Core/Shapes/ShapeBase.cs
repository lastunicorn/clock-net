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
using System.ComponentModel;
using System.Drawing;
using DustInTheWind.ClockNet.Core.Serialization;

namespace DustInTheWind.ClockNet.Core.Shapes
{
    /// <summary>
    /// Provides common functionality for all the shapes.
    /// </summary>
    public abstract class ShapeBase : IShape, ISerializable
    {
        private bool isCacheValid;

        #region Name Property

        private string name;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the
        /// way the shape is rendered.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (name == value)
                    return;

                name = value;
                OnNameChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Visible Property

        /// <summary>
        /// A value specifying if the shape should be drawn or not.
        /// </summary>
        protected bool visible = true;

        /// <summary>
        /// Gets or sets a value specifying if the shape should be drawn or not.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("A value specifying if the shape should be drawn or not.")]
        public virtual bool Visible
        {
            get => visible;
            set
            {
                visible = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Event Changed

        /// <summary>
        /// Event raised when the shape's parameters are changed and it should be rerendered.
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// Raises the <see cref="Changed"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        #endregion

        #region Event NameChanged

        /// <summary>
        /// Event raised when the <see cref="Name"/> property is changed.
        /// </summary>
        public event EventHandler NameChanged;

        /// <summary>
        /// Raises the <see cref="NameChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnNameChanged(EventArgs e)
        {
            NameChanged?.Invoke(this, e);
        }

        #endregion

        /// <summary>
        /// Disposes all the classes used in the drawing process.
        /// This method is called every time when is set a property that needs to regenrate the
        /// drawing tools like <see cref="Brush"/>s and <see cref="Pen"/>s.
        /// </summary>
        protected virtual void DisposeDrawingTools()
        {
        }

        /// <summary>
        /// Marks the current layout as invalid, indicating that a layout update is required.
        /// </summary>
        /// <remarks>Call this method when changes occur that affect the layout, so that the layout system
        /// can recalculate positions and sizes as needed. This method does not immediately update the layout; it only
        /// flags it for a future update.</remarks>
        protected void InvalidateCache()
        {
            isCacheValid = false;
        }

        /// <summary>
        /// Draws the shape using the provided <see cref="ClockDrawingContext"/>.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        public void Draw(ClockDrawingContext context)
        {
            if (!Visible)
                return;

            bool allowToDraw = OnBeforeDraw(context);
            if (!allowToDraw)
                return;

            if (!isCacheValid)
            {
                CalculateCache(context);
                isCacheValid = true;
            }

            OnDraw(context);

            OnAfterDraw(context);
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected virtual void CalculateCache(ClockDrawingContext context)
        {
        }

        /// <summary>
        /// Called before the drawing operation begins, allowing derived classes to perform custom pre-draw logic.
        /// </summary>
        /// <remarks>Override this method in a derived class to implement custom logic that determines
        /// whether the drawing operation should continue. Returning <c>false</c> will prevent the drawing from
        /// occurring.</remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns><c>true</c> if drawing should proceed; otherwise, <c>false</c>.</returns>
        protected virtual bool OnBeforeDraw(ClockDrawingContext context)
        {
            return true;
        }

        /// <summary>
        /// Performs custom drawing operations using the specified drawing context.
        /// </summary>
        /// <remarks>Override this method in a derived class to implement custom rendering logic.</remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected abstract void OnDraw(ClockDrawingContext context);

        /// <summary>
        /// Called after the drawing operation is completed, allowing for custom post-draw logic.
        /// </summary>
        /// <remarks>Override this method in a derived class to perform additional actions after the main
        /// drawing routine has finished. This method is called with the same drawing context used during
        /// drawing.</remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected virtual void OnAfterDraw(ClockDrawingContext context)
        {
        }

        /// <summary>
        /// Serializes the properties of the shape into a dictionary of string key-value pairs.
        /// </summary>
        /// <returns>A dictionary containing the serialized property names and their values.</returns>
        public virtual Dictionary<string, string> Serialize()
        {
            return ShapeSerializer.Default.SerializeProperties(this);
        }

        /// <summary>
        /// Deserializes the shape properties from a dictionary of string key-value pairs.
        /// </summary>
        /// <param name="properties">A dictionary containing the property names and their serialized values.</param>
        public virtual void Deserialize(Dictionary<string, string> properties)
        {
            ShapeSerializer.Default.DeserializeProperties(this, properties);
        }

        #region IDisposable Members

        /// <summary>
        /// A value specifying if the current instance has been disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Event raised after the current instance is disposed.
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>
        /// Raises the <see cref="Disposed"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnDisposed(EventArgs e)
        {
            Disposed?.Invoke(this, e);
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and optionally releases the managed resources.
        /// </summary>
        /// <remarks>
        /// <para>Dispose(bool disposing) executes in two distinct scenarios.</para>
        /// <para>If the method has been called directly or indirectly by a user's code managed and unmanaged resources can be disposed.</para>
        /// <para>If the method has been called by the runtime from inside the finalizer you should not reference other objects. Only unmanaged resources can be disposed.</para>
        /// </remarks>
        /// <param name="disposing">Specifies if the method has been called by a user's code (true) or by the runtime from inside the finalizer (false).</param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!disposed)
            {
                // If disposing equals true, dispose all managed resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    // ...
                }

                // Call the appropriate methods to clean up unmanaged resources here.
                // ...

                disposed = true;

                OnDisposed(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~ShapeBase()
        {
            Dispose(false);
        }

        #endregion
    }
}
