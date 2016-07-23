using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Models
{
	public class FacebookUserModel
	{
		public string bio { get; set; }
		public string id { get; set; }
		public string first_name { get; set; }
		public string middle_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public string birthday { get; set; }
		public string picture_url { get; set; }

		public string DisplayName { get; set; }
		public string Address { get; set; }

	}

	public class FacebookUserProfilePictureModel
	{
		public Data data { get; set; }
	}

	public class Data
	{
		public int height { get; set; }
		public bool is_silhouette { get; set; }
		public string url { get; set; }
		public int width { get; set; }
	}
}
