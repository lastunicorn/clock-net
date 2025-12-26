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
using System.Windows.Forms;

namespace DustInTheWind.ClockNet.TimeProviders
{
    /// <summary>
    /// Implements base functionality for a time provider class.
    /// </summary>
    public abstract class TimeProviderBase : ITimeProvider
    {
        private readonly Timer timer;
        private int interval = 100;

        [Browsable(false)]
        public ISite Site { get; set; }

        /// <summary>
        /// Gets or sets the interval in milliseconds at which the time provider generates time values.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(100)]
        [Description("The interval in milliseconds at which the time provider generates time values.")]
        public int Interval
        {
            get => interval;
            set
            {
                interval = value;
                timer.Interval = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the time provider is currently running.
        /// </summary>
        [Browsable(false)]
        public bool IsRunning => timer.Enabled;

        /// <summary>
        /// Event raised when the time provider produces a new time value.
        /// </summary>
        public event EventHandler<TimeChangedEventArgs> TimeChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeProviderBase"/> class.
        /// </summary>
        protected TimeProviderBase()
        {
            timer = new Timer
            {
                Interval = interval
            };
            timer.Tick += HandleTimerTick;
        }

        private void HandleTimerTick(object sender, EventArgs e)
        {
            TimeSpan time = GetTime();
            OnTimeChanged(new TimeChangedEventArgs(time));
        }

        /// <summary>
        /// Returns the current time value. This method is called internally by the timer.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        protected abstract TimeSpan GetTime();

        /// <summary>
        /// Starts the time provider. The time provider will begin generating time values.
        /// </summary>
        public void Start()
        {
            TimeSpan time = GetTime();
            OnTimeChanged(new TimeChangedEventArgs(time));

            timer.Start();
        }

        /// <summary>
        /// Stops the time provider. The time provider will stop generating time values.
        /// </summary>
        public void Stop()
        {
            timer.Stop();
        }

        /// <summary>
        /// Raises the <see cref="TimeChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TimeChangedEventArgs"/> object that contains the event data.</param>
        protected virtual void OnTimeChanged(TimeChangedEventArgs e)
        {
            TimeChanged?.Invoke(this, e);
        }

        #region IDisposable Members

        /// <summary>
        /// Specifies if the current instance has already been disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Event raised when the current instance is disposed.
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
                    timer.Stop();
                    timer.Tick -= HandleTimerTick;
                    timer.Dispose();
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
        ~TimeProviderBase()
        {
            Dispose(false);
        }

        #endregion
    }
}
