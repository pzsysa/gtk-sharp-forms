// 
//  FormsImage.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
// 
//  Copyright (c) 2011 KrzysztofMarecki
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
using Gdk;

namespace GtkForms
{
	[ToolboxItem(true)]
	public class FormsImage : Gtk.Image
	{
		private ImageDecorator decorator;
		internal ImageDecorator Decorator { 
			get {
				if (decorator == null)
					decorator = new ImageDecorator (this);
				
				return decorator;
			}
		}
		
		public FormsImage ()
			: base ()
		{
		}
		
		public FormsImage (IntPtr raw)
			: base (raw)
		{
		}
		
		public FormsImage (Pixbuf pixbuf)
			: base (pixbuf)
		{
		}
		
		public FormsImage (PixbufAnimation animation)
			: base (animation)
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
		
		public byte[] ImageData {
			get { return Decorator.ImageData; }
			set { 
				Decorator.ImageData = value;
				OnImageDataChanged (EventArgs.Empty);
			}
		}
		
		public new Pixbuf Pixbuf {
			get { return base.Pixbuf; }
			set {
				base.Pixbuf = value;
				OnImageDataChanged (EventArgs.Empty);
			}
		}
		
		public event EventHandler ImageDataChanged;
		
		protected virtual void OnImageDataChanged (EventArgs args)
		{
			var handler = ImageDataChanged;
			if (handler != null) {
				handler (this, args);
			}
		}
	}
}

