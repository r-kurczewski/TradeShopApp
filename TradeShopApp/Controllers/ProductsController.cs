using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TradeShopApp.Data;
using TradeShopApp.Models;

namespace TradeShopApp.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext context;
		private UserManager<ApplicationUser> userManager;

		public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			this.context = context;
			this.userManager = userManager;
		}

		[Authorize]
		public async Task<IActionResult> Index()
		{
			var user = await userManager.GetUserAsync(User);
			var applicationDbContext = context.Products
				.Include(p => p.Category)
				.Where(x => x.Owner.Id == user.Id);
			return View(await applicationDbContext.ToListAsync());
		}

		[Authorize]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) return NotFound();

			var user = await userManager.GetUserAsync(User);
			var product = await context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.ProductId == id);

			if (product == null)
			{
				return NotFound();
			}
			else if (product.OwnerId != user.Id)
			{
				return Forbid();
			}

			return View(product);
		}

		public IActionResult Create()
		{
			ViewData["Category"] = new SelectList(context.Categories, "CategoryId", "CategoryName");
			return View();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ProductId,CategoryId,ProductName,Quantity,Price,ThumbnailPath,ShortDescription,LongDescription,OfferDetails")] Product product)
		{
			if (ModelState.IsValid)
			{
				product.OwnerId = (await userManager.GetUserAsync(User)).Id;
				context.Add(product);
				await context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["Category"] = new SelectList(context.Categories, "CategoryId", "CategoryName", product.Category);
			return View(product);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();

			var user = await userManager.GetUserAsync(User);
			var product = await context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			else if (product.OwnerId != user.Id)
			{
				return Forbid();
			}

				ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryId", product.CategoryId);
			return View(product);
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ProductId,CategoryId,ProductName,Quantity,Price,ThumbnailPath,ShortDescription,LongDescription,OfferDetails")] Product product)
		{
			if (id != product.ProductId) return NotFound();
			var user = await userManager.GetUserAsync(User);
			if (product.OwnerId != user.Id) return Forbid();

			if (ModelState.IsValid)
			{
				try
				{
					context.Update(product);
					await context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(product.ProductId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryId", product.CategoryId);
			return View(product);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return NotFound();
			var user = await userManager.GetUserAsync(User);
			var product = await context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.ProductId == id);
			
			if (product == null)
			{
				return NotFound();
			}
			else if(product.OwnerId != user.Id)
			{
				return Forbid();
			}

			return View(product);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var user = await userManager.GetUserAsync(User);
			var product = await context.Products.FindAsync(id);
			if(product.OwnerId != user.Id)
			{
				return Forbid();
			}
			context.Products.Remove(product);
			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(int id)
		{
			return context.Products.Any(e => e.ProductId == id);
		}
	}
}
