using PulsoPH.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Helper
{
	public class ResultHelper
	{
		public static ResultValue ReturnValue(bool result, object message)
		{
			dynamic expando = new ResultValue();
			expando.Result = result;
			expando.Message = message;
			return expando;
		}
	}
}
