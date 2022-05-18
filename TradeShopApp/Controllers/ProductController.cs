using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeShopApp.Data;
using TradeShopApp.Models;

namespace TradeShopApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext context;

		public ProductController(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IActionResult Details(int id)
		{
			try
			{
			
				var model = context.Products.Include(x=> x.Owner).First(x => x.ProductId == id);
				return View(model);
			}
			catch (InvalidOperationException)
			{
				return NotFound();
			}
		}
	}
}
