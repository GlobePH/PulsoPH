using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Models
{
	public class Paging
	{
		public double TotalCount { get; set; }
		public double PageCount { get; set; }
		public dynamic Output { get; set; }
	}

	public class NotificationObject : INotifyPropertyChanged
	{
		public void RaisePropertyChanged(string propName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
