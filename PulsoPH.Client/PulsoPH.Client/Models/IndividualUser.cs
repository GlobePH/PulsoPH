using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Models
{
	public class IndividualUser
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string FacebookId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Nickname { get; set; }
		public string Address { get; set; }
		public DateTime BirthDate { get; set; }
		public string PhotoUrl { get; set; }
	}

	public class IndividualUserRegAuth : IndividualUser
	{
		public string Source { get; set; }
	}
}
