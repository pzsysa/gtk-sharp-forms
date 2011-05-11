// 
//  FormsComboBoxEntry.cs
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
using System.ComponentModel;

using Gtk;

namespace GtkForms
{
	public class FormsComboBoxEntry : Gtk.ComboBoxEntry, IBindableComponent, IDecoratedListWidget, IListWidget
	{
		private ListWidgetDecorator<FormsComboBoxEntry> decorator;
		internal ListWidgetDecorator<FormsComboBoxEntry> Decorator { 
			get {
				if (decorator == null) {
					decorator = new  ListWidgetDecorator<FormsComboBoxEntry>(this);
					decorator.CellRenderExists = true;
				}
				
				return decorator;
			}
		}

		public FormsComboBoxEntry ()
			: base ()
		{
		}

		
		public FormsComboBoxEntry (IntPtr raw)
			: base (raw)
		{
		}
		
		public FormsComboBoxEntry (string[] entries)
			: base (entries)
		{
		}
		
		#region IBindableComponent implementation
		public event EventHandler HandleCreated {
			add { Decorator.HandleCreated += value; }
			remove { Decorator.HandleCreated -= value; }
		}
	
		public event CancelEventHandler Validating {
			add { Decorator.Validating += value; }
			remove { Decorator.Validating -= value; }
		}
		
		
		public BindingContext BindingContext {
			get { return Decorator.BindingContext; }
			set { Decorator.BindingContext = value; }
		}
		
		
		public ControlBindingsCollection DataBindings { get { return Decorator.DataBindings; } }
		
		public bool IsHandleCreated { get { return Decorator.IsHandleCreated; } }
		#endregion
		
		#region IListWidget implementation
		
		public object DataSource {
			get { return Decorator.DataSource; }
			set { Decorator.DataSource = value; }
		}
		
		[Browsable (true)]
		public string DisplayMember {
			get { return Decorator.DisplayMember; }
			set { Decorator.DisplayMember = value; }
		}
		
		[Browsable (true)]
		public string ValueMember {
			get { return Decorator.ValueMember; }
			set { Decorator.ValueMember = value; }
		}
		#endregion
		
		#region IDecoratedListWidget implementation
		
		TreeModel IDecoratedBaseListWidget.Model {
			get { return Model; }
			set { 
				TextColumn = 0;
				Model = value; 
			}
		}
	
		#endregion
		
		public Gdk.Color BackgroundColor {
			get { return Decorator.BackgroundColor; }
			set { Decorator.BackgroundColor = value; }
		}
		
		public int FontSize {
			get { return Decorator.FontSize; }
			set { Decorator.FontSize = value; }
		}
		
		public object SelectedItem {
			get { return Decorator.SelectedItem; }
			set { Decorator.SelectedItem = value; }
		}
		
		public int SelectedIndex {
			get { return Decorator.SelectedIndex; }
			set { Decorator.SelectedIndex = value; }
		}
		
		public string Text {
			get { return Entry.Text; }
			set { Entry.Text = value; }
		}
		
		protected override void OnChanged ()
		{
			base.OnChanged ();
			
			TreeIter iter;
			if (GetActiveIter (out iter))
				Decorator.SetPositionFromIter (iter);
		}
		
		protected override bool OnSelectionNotifyEvent (Gdk.EventSelection evnt)
		{
			bool ret = base.OnSelectionNotifyEvent (evnt);
			OnSelectedIndexChanged (EventArgs.Empty);
			OnSelectedItemChanged (EventArgs.Empty);
			return ret;
		}
		
		protected void OnSelectedIndexChanged (EventArgs args)
		{
			var handler = SelectedIndexChanged;
			if (handler != null) {
				handler (this, args);
			}
		}
		
		protected void OnSelectedItemChanged (EventArgs args)
		{
			var handler = SelectedItemChanged;
			if (handler != null) {
				handler (this, args);
			}
		}
		
		public event EventHandler SelectedIndexChanged;
		
	 	public event EventHandler SelectedItemChanged; 
			
		[EditorBrowsable (EditorBrowsableState.Never)]
		public event EventHandler TextChanged {
			add { Entry.Changed += value; }
			remove { Entry.Changed -= value; }
		}
	}
}

