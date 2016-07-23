using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Models
{
	public class MasterPageItem
	{
		public string Title { get; set; }
		public string IconSource { get; set; }
		public Type TargetType { get; set; }
		public Type TargetTypeSearchResult { get; set; }
		public Type TargetTypeDetail { get; set; }
	}
}
