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
using System.ComponentModel;
using System.Drawing;

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// Provides common functionality for all the shapes.
    /// </summary>
    public abstract class ShapeBase : IShape
    {
        private string name;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                name = value;
            }
        }

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
            get { return visible; }
            set
            {
                visible = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #region Event Changed

        /// <summary>
        /// Event raised when the shape's parameters are changed and it should be redrawn.
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// Raises the <see cref="Changed"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        #endregion


        /// <summary>
        /// Disposes all the classes used in the drawing process.
        /// This method is called every time when is set a property that changes the way the Shape is drawn.
        /// Examples: the color, the width of the line, etc.
        /// </summary>
        protected virtual void InvalidateDrawingTools()
        {
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected virtual void CalculateDimensions()
        {
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected virtual bool AllowToDraw()
        {
            return visible;
        }

        /// <summary>
        /// Draws the shape using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        public virtual void Draw(Graphics g)
        {
            if (AllowToDraw())
            {
                DrawInternal(g);
            }
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="DrawInternal"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected abstract void DrawInternal(Graphics g);


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
            if (Disposed != null)
                Disposed(this, e);
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
            if (!this.disposed)
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
