using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TradeShopApp.Data;
using TradeShopApp.Models;
using static TradeShopApp.Models.MyExtensions;

namespace TradeShopApp.Controllers
{
	public class SearchController : Controller
	{
		private readonly ApplicationDbContext context;

		public SearchController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public IActionResult Index([FromQuery] SearchOptions options)
		{
			var model = new SearchViewModel();
			model.SearchOptions = options;
			var selectedCategory = context.Categories.FirstOrDefault(x => x.CategoryName == options.CategoryName);
			model.CategorySelectItems = new SelectList(context.Categories, "CategoryName", "CategoryName", selectedCategory?.CategoryName);
			model.CategorySelectItems = model.CategorySelectItems.Prepend(new SelectListItem("All", ""));
			model.Results = context.Products;

			if (options.Query != null)
			{
				model.Results = model.Results
					.Where(x => x.ProductName.ContainsIgnoreCase(options.Query)
					|| x.ShortDescription.ContainsIgnoreCase(options.Query));
			}
			if (options.CategoryName != null)
			{
				var searchCategories = GetSubCategories(selectedCategory).ToList();
				model.Results = model.Results.Where(x => searchCategories.Contains(x.Category));
			}
			if (options.PriceMin != null)
			{
				model.Results = model.Results.Where(x => x.Price > options.PriceMin);
			}
			if (options.PriceMax != null)
			{
				model.Results = model.Results.Where(x => x.Price < options.PriceMax);
			}
			return View(model);
		}

		private IEnumerable<Category> GetSubCategories(Category category)
		{
			if (category == null) return context.Categories;

			var result = new List<Category>();
			var childList = context.Categories.ToLookup(c => c.ParentCategoryId);
			var toCheck = new List<Category>
			{
				category
			};

			//check for another tree levels
			while (toCheck.Count > 0)
			{
				result.AddRange(toCheck);
				var nextToCheck = new List<Category>();

				// check all children
				foreach (var cat in toCheck)
				{
					var catChildren = childList[cat.CategoryId].ToList();
					nextToCheck.AddRange(catChildren);
				}
				toCheck = nextToCheck;
			}
			return result;
		}
	}
}