// 
// GtkExtensions.cs
//  
// Author:
//       Jonathan Pobst <monkey@jpobst.com>
// 
// Copyright (c) 2010 Jonathan Pobst
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Gtk;

namespace GtkForms.Extensions
{
	public static class GtkExtensions
	{
		public static void AddWidgetItem (this Toolbar tb, Widget w)
		{
			w.Show ();
			ToolItem ti = new ToolItem ();
			ti.Add (w);
			ti.Show ();
			tb.Insert (ti, tb.NItems);
		}
		
		public static void AppendItem (this Toolbar tb, ToolItem item)
		{
			item.Show ();
			tb.Insert (item, tb.NItems);
		}
		
		public static void AppendSeparator (this Menu menu)
		{
			SeparatorMenuItem smi = new SeparatorMenuItem ();
			smi.Show ();
			menu.Append (smi);
		}

		public static MenuItem AppendItem (this Menu menu, MenuItem item)
		{
			menu.Append (item);
			return item;
		}
		
		public static Gtk.Action AppendAction (this Menu menu, string actionName, string actionLabel, string actionTooltip, string actionIcon)
		{
			Gtk.Action action = new Gtk.Action (actionName, actionLabel, actionTooltip, actionIcon);
			menu.AppendItem ((MenuItem)action.CreateMenuItem ());
			return action;
		}
		
		public static Gtk.ToolItem CreateToolBarItem (this Gtk.Action action)
		{
			Gtk.ToolItem item = (Gtk.ToolItem)action.CreateToolItem ();
			item.TooltipText = action.Label;
			return item;
		}

		public static Gtk.MenuItem CreateSubMenuItem (this Gtk.Action action)
		{
			MenuItem item = (MenuItem)action.CreateMenuItem ();
			
			Menu sub_menu = new Menu ();
			item.Submenu = sub_menu;

			return item;
		}
	}
}
