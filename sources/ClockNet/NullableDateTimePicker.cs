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
using System.Windows.Forms;
using System.ComponentModel;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// An <see cref="UserControl"/> that similar to the <see cref="DateTimePicker"/> control
    /// but which additionally provides the ability to return a null value instead of a <see cref="DateTime"/>.
    /// </summary>
    public partial class NullableDateTimePicker : UserControl
    {
        /// <summary>
        /// Specifies if the control contains a null value or a <see cref="DateTime"/> value.
        /// </summary>
        private bool isNull = true;

        /// <summary>
        /// Gets or sets a value that specifies if the control contains a null value or a <see cref="DateTime"/> value.
        /// </summary>
        [Browsable(false)]
        public bool IsNull
        {
            get { return isNull; }
            private set
            {
                tableLayoutPanel1.Visible = !value;
                buttonCreate.Visible = value;
                isNull = value;
            }
        }

        #region Event ValueChanged

        /// <summary>
        /// Event raised when ... Well, is raised when it should be raised. Ok?
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Raises the <see cref="ValueChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableDateTimePicker"/> class.
        /// </summary>
        public NullableDateTimePicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control, but keeps the height equal with
        /// the height od the <see cref="DateTimePicker"/> control.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="specified"></param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, DateTimePicker.Height, specified);
        }

        /// <summary>
        /// Gets or sets the value displayed by the control.
        /// </summary>
        public DateTime? Value
        {
            get { return isNull ? null : (DateTime?)DateTimePicker.Value; }
            set
            {
                if (value == null)
                {
                    isNull = true;
                }
                else
                {
                    DateTimePicker.Value = value.Value;
                }
            }
        }

        bool initializing = false;

        /// <summary>
        /// Call-back method that handles the Click event of the Create button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                initializing = true;

                DateTimePicker.Value = DateTime.Now.Date;
                IsNull = false;
                OnValueChanged(EventArgs.Empty);
            }
            finally
            {
                initializing = false;
            }
        }

        /// <summary>
        /// Call-back method that handles the ValueChanged event of the time picker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!initializing)
            {
                IsNull = false;
                OnValueChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Call-back method that handles the Click event of the Null button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNull_Click(object sender, EventArgs e)
        {
            IsNull = true;
            OnValueChanged(EventArgs.Empty);
        }
    }
}
