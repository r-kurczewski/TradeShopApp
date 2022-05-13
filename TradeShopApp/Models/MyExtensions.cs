using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public static class MyExtensions
	{
		public static bool ContainsIgnoreCase(this string str, string toCheck)
		{
			return str?.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}
}
