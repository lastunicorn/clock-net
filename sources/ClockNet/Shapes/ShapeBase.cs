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
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        [Browsable(false)]
        public abstract string Name { get; }

        /// <summary>
        /// A value specifying if the shape should be drawn or not.
        /// </summary>
        protected bool visible = true;

        /// <summary>
        /// Gets or sets a value specifying if the shape should be drawn or not.
        /// </summary>
        [Category("Appearance")]
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
        /// </summary>
        protected virtual void InvalidateDrawingTools()
        {
        }

        /// <summary>
        /// Draws the shape using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        public abstract void Draw(Graphics g);


        #region IDisposable Members

        private bool disposed = false;

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

        public event EventHandler Disposed;
        protected virtual void OnDisposed(EventArgs e)
        {
            if (Disposed != null)
                Disposed(this, e);
        }

        private ISite site;
        public ISite Site
        {
            get
            {
                return site;
            }
            set
            {
                site = value;
            }
        }
    }
}
