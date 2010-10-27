// 
//  FormsDatePicker.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
// 
//  Copyright (c) 2010 Krzysztof Marecki
// 
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
// 
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
using System;
using System.Globalization;
using GtkForms;

namespace GtkForms.Custom
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class DatePicker : Gtk.Bin, IFocusableWidget
	{
		CalendarWindow calendwnd;
			
		
		public DatePicker ()
		{
			this.Build ();
			
			button.Clicked += HandleButtonClicked;
			entry.Changed += HandleEntryChanged;
			entry.FocusOutEvent += HandleEntryFocusOutEvent;
		}
	
		public string CustomFormat { get; set; }
		
		public DateTime Date {
			get {
				DateTime date;
				if (DateTime.TryParse (entry.Text, out date))
					return date;
				
				return DateTime.Now;
			}
			set {
				if (Date != value) {
					string format = GetDateFormat ();
					entry.Text = value.ToString (format);
				}
			}
		}
		
		
		public override void Dispose ()
		{
			base.Dispose ();
			
			if (calendwnd != null) {
				calendwnd.Destroy ();
			}
		}
		
		
		string GetDateFormat ()
		{
			return string.IsNullOrEmpty (CustomFormat) ?
				CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern :
				CustomFormat;	
		}
	
		void HandleButtonClicked (object sender, EventArgs e)
		{
			if (calendwnd == null) {
				calendwnd = new CalendarWindow ();
				calendwnd.Hidden += HandleCalendwndHidden;
			}
			calendwnd.Date = Date;
			
			int x, y;
			ParentWindow.GetPosition( out x, out y );	
			x += this.Allocation.Left;
			y += this.Allocation.Top + this.Allocation.Height;
			calendwnd.Move (x, y);
			calendwnd.Modal = true;
			calendwnd.Show ();
		}

		void HandleCalendwndHidden (object sender, EventArgs e)
		{
			Date = calendwnd.Date;
			entry.GrabFocus ();
			entry.Position = entry.Text.Length;
		}
		
		void HandleEntryChanged (object sender, EventArgs e)
		{
			OnDateChanged ();
		}
		
		[GLib.ConnectBefore]
		void HandleEntryFocusOutEvent (object sender, Gtk.FocusOutEventArgs e)
		{
			OnFocusOut ();
		}
		
		
		public event EventHandler DateChanged;
		
		protected virtual void OnDateChanged ()
		{
			var handler = DateChanged;
			if (handler != null) 
				handler (this, EventArgs.Empty);
		}
		
		public event EventHandler FocusOut;
		
		protected virtual void OnFocusOut ()
		{
			var handler = FocusOut;
			if (handler != null)
				handler (this, EventArgs.Empty);
		}
	}
}

