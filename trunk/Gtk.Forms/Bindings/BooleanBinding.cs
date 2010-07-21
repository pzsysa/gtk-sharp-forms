// 
//  BooleanEnumBinding.cs
//  
//  Author:
//       Krzysztof Marecki <freefirma@gmail.com>
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
using Gtk;

namespace GtkForms
{
	public class BooleanBinding<T> : Binding
		where T : IComparable
	{
		public BooleanBinding (string propertyName,
		                           object dataSource,
		                           string dataMember,
		                           T trueValue)
			: base (propertyName, dataSource, dataMember)
		{
			TrueValue = trueValue;
			FormattingEnabled = true;
		}
		
		public T TrueValue { get; set; }
		
		protected override void OnFormat (ConvertEventArgs e)
		{
			base.OnFormat (e);
			
			T s = (T) e.Value;
			e.Value = (s.CompareTo(TrueValue) == 0);
		}
		
		protected override void OnParse (ConvertEventArgs e)
		{
			base.OnParse (e);
			
			bool b = (bool) e.Value;
			if (b)
				e.Value = TrueValue;
			else
				e.Cancel = true;
		}
		
		protected override void OnBindingComplete (BindingCompleteEventArgs e)
		{
			base.OnBindingComplete (e);
			
			if (typeof(RadioButton).IsAssignableFrom (Control.GetType ())) {
				//DataSourceUpdateMode.OnValidating does not work with RadioButtons
				DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
			}
		}
	}
}

