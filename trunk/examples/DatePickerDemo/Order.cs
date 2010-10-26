// 
//  Order.cs
//  
//  Author:
//       Krzysztof Marecki <marecki.krzysztof@gmail.com>
// 
//  Copyright (c) 2010 KrzysztofMarecki
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

namespace DatePickerDemo
{
	public class Order : INotifyPropertyChanged
	{
		public Order ()
		{
			DeliveryDate = DateTime.Now;
			OrderDate = DateTime.Now;
		}
		
		private DateTime deliveryDate;
		public DateTime DeliveryDate 
		{
		    get { return deliveryDate; }
		    set
		    {
		        if (deliveryDate != value)
		        {
		            deliveryDate = value;
		            OnPropertyChanged ("DeliveryDate");
		        }
		    }
		}
		
		private DateTime orderDate;
		public DateTime OrderDate 
		{
		    get { return orderDate; }
		    set
		    {
		        if (orderDate != value)
		        {
		            orderDate = value;
		            OnPropertyChanged ("OrderDate");
		        }
		    }
		}
		
		
		#region INotifyPropertyChanged Members

		protected void OnPropertyChanged(string name)
		{
		    if (PropertyChanged != null)
		        PropertyChanged (this, new PropertyChangedEventArgs(name));
		}
		
		public event PropertyChangedEventHandler PropertyChanged;

        	#endregion
	}
}

