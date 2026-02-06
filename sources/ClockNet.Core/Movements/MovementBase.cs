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
using System.Threading;

namespace DustInTheWind.ClockNet.Core.Movements
{
    /// <summary>
    /// Implements base functionality for a time provider class.
    /// </summary>
    public abstract class MovementBase : IMovement
    {
        private readonly Timer timer;

        [Browsable(false)]
        public ISite Site { get; set; }

        #region TickInterval Property

        private int tickInterval = 100;

        /// <summary>
        /// Gets or sets the interval in milliseconds at which the time provider generates time values.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(100)]
        [Description("The interval in milliseconds at which the time current instance generates time values.")]
        public int TickInterval
        {
            get => tickInterval;
            set
            {
                if (tickInterval == value)
                    return;

                tickInterval = value;

                if (IsRunning)
                {
                    if (tickInterval > 0)
                        timer.Change(0, tickInterval);
                    else
                        timer.Change(Timeout.Infinite, Timeout.Infinite);
                }

                OnModified();
            }
        }

        #endregion

        /// <summary>
        /// Gets a value indicating whether the time provider is currently running.
        /// </summary>
        [Browsable(false)]
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Gets the most recently provided value.
        /// </summary>
        [Browsable(false)]
        public TimeSpan LastTick { get; private set; }

        /// <summary>
        /// Occurs when the object is modified.
        /// </summary>
        /// <remarks>
        /// Subscribers can use this event to respond to changes in the object's state or content. The
        /// event is typically raised after a modification operation completes.
        /// </remarks>
        public event EventHandler Modified;

        /// <summary>
        /// Event raised when the time provider produces a new time value.
        /// </summary>
        public event EventHandler<TickEventArgs> Tick;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovementBase"/> class.
        /// </summary>
        protected MovementBase()
        {
            timer = new Timer(HandleTimerCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        private void HandleTimerCallback(object state)
        {
            LastTick = GenerateNewTime();
            OnTick(new TickEventArgs(LastTick));
        }

        /// <summary>
        /// Returns the current time value. This method is called internally by the timer.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        protected abstract TimeSpan GenerateNewTime();

        /// <summary>
        /// Starts the time provider. The time provider will begin generating time values.
        /// </summary>
        public void Start()
        {
            if (tickInterval > 0)
            {
                timer.Change(0, tickInterval);
            }
            else
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                ForceTick();
            }

            IsRunning = true;
        }

        /// <summary>
        /// Stops the time provider. The time provider will stop generating time values.
        /// </summary>
        public void Stop()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            IsRunning = false;
        }

        /// <summary>
        /// Forces the timer to perform a tick operation immediately, updating the last tick time and raising the tick
        /// event.
        /// </summary>
        /// <remarks>
        /// This method bypasses any scheduled timing and triggers the tick logic as if the timer
        /// interval had elapsed. It can be used to manually advance the timer state or to simulate a tick for testing or
        /// synchronization purposes.
        /// </remarks>
        protected void ForceTick()
        {
            LastTick = GenerateNewTime();
            OnTick(new TickEventArgs(LastTick));
        }

        /// <summary>
        /// Raises the Modified event to notify subscribers that the object has been changed.
        /// </summary>
        /// <remarks>Derived classes can override this method to provide additional behavior when the object is
        /// modified. This method is typically called after a change to the object's state that should trigger
        /// notification.</remarks>
        protected virtual void OnModified()
        {
            Modified?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the <see cref="Tick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TickEventArgs"/> object that contains the event data.</param>
        protected virtual void OnTick(TickEventArgs e)
        {
            Tick?.Invoke(this, e);
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
                    timer.Change(Timeout.Infinite, Timeout.Infinite);
                    timer.Dispose();
                    IsRunning = false;
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
        ~MovementBase()
        {
            Dispose(false);
        }

        #endregion
    }
}
