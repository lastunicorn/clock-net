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
using System.Drawing;
using System.ComponentModel;

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
        /// The clock's real width. Usefull for the shape to know how big it should draw itself.
        /// </summary>
        protected float clockWidth = 100;

        /// <summary>
        /// Gets or sets the clock's real width. Usefull for the shape to know how big it should draw itself.
        /// Default value = 100
        /// </summary>
        [Browsable(false)]
        public float ClockWidth
        {
            get { return clockWidth; }
            set
            {
                if (clockWidth <= 0)
                    throw new ArgumentOutOfRangeException("value", "The clock's width should be a number greater then zero.");

                clockWidth = value;
                OnClockWidthChanged();
            }
        }

        protected virtual void OnClockWidthChanged()
        {
        }

        #region Event Changed

        /// <summary>
        /// Event raised when the shape's parameters are changed and it should be redrown.
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
