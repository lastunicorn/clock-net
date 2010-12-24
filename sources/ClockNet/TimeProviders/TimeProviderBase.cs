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

namespace DustInTheWind.Clock.TimeProviders
{
    /// <summary>
    /// Implements base functionality for a time provider class.
    /// </summary>
    public abstract class TimeProviderBase : ITimeProvider
    {
        #region Event Changed

        /// <summary>
        /// Event raised when the internal mechanism that generates time values is changed and therefore
        /// the already generated time values are obsolete. The clients should request new time values using
        /// <see cref="GetTime"/> method.
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
        /// Returns a new time value.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        public abstract TimeSpan GetTime();

        public event EventHandler Disposed;

        protected virtual void OnDisposed(EventArgs e)
        {
            if (Disposed != null)
            {
                Disposed(this, e);
            }
        }

        private ISite site;
        public ISite Site
        {
            get { return site; }
            set { site = value; }
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                OnDisposed(EventArgs.Empty);
            }
        }

        ~TimeProviderBase()
        {
            Dispose(false);
        }
    }
}
