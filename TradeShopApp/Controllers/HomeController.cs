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
		private readonly ILogger<HomeController> logger;
		private readonly ApplicationDbContext dbContext;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
		{
			this.logger = logger;
			this.dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var categories = dbContext.Categories.ToList();

			var categoryNodes = categories.
				Select(c => new CategoryNode(c))
				.ToList();

			var childsHash = categoryNodes.ToLookup(node => node.category.ParentCategoryId);

			foreach (var node in categoryNodes)
			{
				node.nodes = childsHash[node.category.CategoryId].ToList();
			}
			categoryNodes = categoryNodes
				.Where(c => !c.category.ParentCategoryId.HasValue)
				.ToList();

			ViewBag.Categories = categoryNodes;
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
