using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeShopApp.Data;
using TradeShopApp.Models;

namespace TradeShopApp.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext context;

		public ProductsController(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IActionResult Details(int id)
		{
			try
			{
				var model = new ProductViewModel();
				model.product = context.Products.First(x => x.ProductId == id);
				return View(model);
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}
		}
	}
}
