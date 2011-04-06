// 
//  ImageDecorator.cs
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
using Gdk;
using Gtk;

namespace GtkForms
{
	public class ImageDecorator : WidgetDecorator
	{
		Gtk.Image image;
		
		public ImageDecorator (Gtk.Image widget)
			: base (widget)
		{
			image = widget;
		}
		
		public byte[] ImageData {
			get {
				if (image.Pixbuf == null) {
					return null;
				}
				//Pixdata data = new Pixdata ();
				//data.FromPixbuf (image.Pixbuf, false);
				//return data.Serialize ();
				return image.Pixbuf.SaveToBuffer ("png");
			}
			set {
				if (value != null) {
//					Pixdata data = new Pixdata ();
//					data.Deserialize ((uint)value.Length, value); 
//					Pixbuf pixbuf = Pixbuf.FromPixdata (data, true);
//					image.Pixbuf = pixbuf;
					Pixbuf pixbuf = new Pixbuf (value);
					image.Pixbuf = pixbuf;
				} else {
					image.Pixbuf = null;
				}
			}
		}
	}
}

