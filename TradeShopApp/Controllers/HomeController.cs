using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TradeShopApp.Data;
using TradeShopApp.Models;

namespace TradeShopApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext context;

		public HomeController(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			var categoryTree = Node<Category>.GetTree(context.Categories.ToList());
			var model = new HomeViewModel();
			model.CategoryTree = categoryTree;
			model.ProductsDisplay = context.Products
				.Include(x => x.Owner)
				.Take(5)
				.ToList();
			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}
	}
}
