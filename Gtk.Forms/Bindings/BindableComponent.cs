// 
//  BindableComponent.cs
//  
//  Author:
//       Krzysztof Marecki 
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

namespace GtkForms
{
	public abstract class BindableComponent : IBindableComponent
	{	
		#region IBindableComponent implementation
		
		public virtual BindingContext BindingContext {
			get {
				return GetBindingContext ();
			}
			set {
				throw new ApplicationException ("BindingContext is readonly property for BindableComponent");
			}
		}
		
		private ControlBindingsCollection data_bindings;
		public ControlBindingsCollection DataBindings {
			get {
				if (data_bindings == null) {
					var bindable = (IBindableComponent) this;
					data_bindings = new ControlBindingsCollection (bindable);
				}
				return data_bindings;
			}
		}
		
		public event EventHandler HandleCreated;
		
		public event CancelEventHandler Validating;
		
		#endregion
		
		protected abstract BindingContext GetBindingContext ();
	}
}

