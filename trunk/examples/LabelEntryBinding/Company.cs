using System;
using System.ComponentModel;


public class Company : INotifyPropertyChanged
{
	#region INotifyPropertyChanged Members

	public event PropertyChangedEventHandler PropertyChanged;

	#endregion

	private string companyName;
	public string CompanyName {
		get { return companyName; }
		set {
			if (companyName != value) {
				companyName = value;
				if (PropertyChanged != null)
					PropertyChanged (this, new PropertyChangedEventArgs ("CompanyName"));
			}
		}
	}

	Adress adress = new Adress ();
	public Adress Adress {
		get { return adress; }
	}
}

public class Adress : INotifyPropertyChanged
{
	#region INotifyPropertyChanged Members

	public event PropertyChangedEventHandler PropertyChanged;

	#endregion

	private string street;
	public string Street {
		get { return street; }
		set {
			if (street != value) {
				street = value;
				if (PropertyChanged != null)
					PropertyChanged (this, new PropertyChangedEventArgs ("Street"));
			}
		}
	}
}
