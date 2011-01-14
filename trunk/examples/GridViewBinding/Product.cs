
using System;
using System.ComponentModel;



	public class Product : INotifyPropertyChanged
	{
		private string productName;
        public string ProductName 
        {
            get { return productName; }
            set
            {
                if (productName != value)
                {
                    productName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }

        private int productID;
        public int ProductID
        {
            get { return productID; }
            set
            {
                if (productID != value)
                {
                    productID = value;
                    OnPropertyChanged("ProductID");
                }
            }
        }
		
		private decimal price;
		public decimal Price
		{
			get { return price; }
			set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
		}
		
		private bool favourite;
		public bool Favourite
		{
			get { return favourite; }
			set 
			{
				if (favourite != value)
				{
					favourite = value;
					OnPropertyChanged("Favourite");
				}
			}
		}
		
		public Product ()
		{
		}
		
		#region INotifyPropertyChanged Members

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
	}

