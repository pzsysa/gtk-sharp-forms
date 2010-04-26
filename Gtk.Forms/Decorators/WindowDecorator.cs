// 
//  FormAdapter.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
//  
//  Copyright (c) 2010 Krzysztof Marecki
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.ComponentModel;

using Gtk;

namespace Gtk.Forms
{
	internal class WindowDecorator : ContainerDecorator
	{
		private Window window;
		
		public WidgetDecorator Focused { get; set; }
		
		public WindowDecorator (Window widget)
			: base (widget)
		{
			window = widget;
			window.DeleteEvent += window_DeleteEvent;
		}
		
		[GLib.ConnectBefore]
		void window_DeleteEvent (object o, DeleteEventArgs args)
		{
			if(Focused != null) {
	
				if(!Focused.Validated)
					args.RetVal=true;
			}
		}

		#region Protected Methods
		
		#endregion
	}
}

