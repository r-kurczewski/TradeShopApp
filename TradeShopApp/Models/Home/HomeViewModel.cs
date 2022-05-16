using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public class HomeViewModel
	{
		public Node<Category> CategoryTree { get; set; }

		public IEnumerable<Product> ProductsDisplay { get; set; }
	}
}
