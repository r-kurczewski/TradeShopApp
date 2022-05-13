using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	[Serializable]
	public class SearchOptions
	{
		public string Query { get; set; }
		[FromQuery(Name ="category")]
		public string CategoryName { get; set; }
		public int? PriceMin { get; set; }
		public int? PriceMax { get; set; }
	}
}
