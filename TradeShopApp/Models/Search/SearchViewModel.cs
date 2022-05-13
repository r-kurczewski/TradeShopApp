using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TradeShopApp.Models
{
	public class SearchViewModel
	{
		public SearchOptions SearchOptions { get; set; }

		public IEnumerable<SelectListItem> CategorySelectItems { get; set; }

		public IEnumerable<Product> Results { get; set; }
	}
}