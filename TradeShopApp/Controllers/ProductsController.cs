using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TradeShopApp.Data;
using TradeShopApp.Models;
using Files = System.IO.File;

namespace TradeShopApp.Controllers
{
	[Authorize]
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext context;
		private UserManager<ApplicationUser> userManager;
		private IWebHostEnvironment environment;

		public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
		{
			this.context = context;
			this.userManager = userManager;
			this.environment = environment;
		}

		public async Task<IActionResult> Index()
		{
			var user = await userManager.GetUserAsync(User);
			var applicationDbContext = context.Products
				.Include(p => p.Category)
				.Where(x => x.Owner.Id == user.Id);
			return View(await applicationDbContext.ToListAsync());
		}

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
		public async Task<IActionResult> Create([Bind("ProductId,CategoryId,ProductName,Quantity,Price,UploadedPhoto,ShortDescription,LongDescription,OfferDetails")] Product product)
		{
			if (ModelState.IsValid)
			{
				product.OwnerId = (await userManager.GetUserAsync(User)).Id;
				context.Add(product);
				await context.SaveChangesAsync();
				product.ThumbnailPath = await SaveProductImage(product);
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
			ViewData["Category"] = new SelectList(context.Categories, "CategoryId", "CategoryName", product.Category);
			return View(product);
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ProductId,CategoryId,OwnerId,ProductName,Quantity,Price,UploadedPhoto,ShortDescription,LongDescription,OfferDetails")] Product product)
		{
			var found = context.Products.AsNoTracking().First(x => x.ProductId == id);
			if (found == null) return NotFound();
			var user = await userManager.GetUserAsync(User);
			if (found.OwnerId != user.Id) return Forbid();

			if (ModelState.IsValid)
			{
				try
				{
					if (product.UploadedPhoto != null)
					{
						product.ThumbnailPath = await SaveProductImage(product);
					}
					context.Update(product);
					context.Entry(product).Property(x => x.ProductId).IsModified = false;
					context.Entry(product).Property(x => x.OwnerId).IsModified = false;
					context.Entry(product).Property(x => x.ThumbnailPath).IsModified = product.UploadedPhoto != null;
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
			else if (product.OwnerId != user.Id)
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
			if (product.OwnerId != user.Id)
			{
				return Forbid();
			}
			context.Products.Remove(product);
			DeleteProductImage(product);
			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private async Task<string> SaveProductImage(Product product)
		{
			string root = environment.WebRootPath;
			string imgFolder = GetImageFolder(product);
			string fileName = GetImageFileName(product);

			Directory.CreateDirectory(Path.Combine(root, imgFolder));
			using (var fileStream = new FileStream(Path.Combine(root, imgFolder, fileName), FileMode.Create))
			{
				await product.UploadedPhoto.CopyToAsync(fileStream);
			}
			return Path.DirectorySeparatorChar + Path.Combine(imgFolder, fileName);
		}

		private void DeleteProductImage(Product product)
		{
			string file = Path.Combine(environment.WebRootPath, product.ThumbnailPath.Trim('\\'));
			string folder = Path.Combine(environment.WebRootPath, GetImageFolder(product));
			Files.Delete(file);
			bool emptyFolder = !Directory.EnumerateFileSystemEntries(folder).Any();
			if (emptyFolder) Directory.Delete(folder);
			
		}

		private bool ProductExists(int id)
		{
			return context.Products.Any(e => e.ProductId == id);
		}

		private static string GetImageFileName(Product product)
		{
			return "img0" + Path.GetExtension(product.UploadedPhoto.FileName);
		}

		private static string GetImageFolder(Product product)
		{
			return Path.Combine("uploads" + Path.DirectorySeparatorChar + "photos", product.ProductId.ToString());
		}
	}
}
