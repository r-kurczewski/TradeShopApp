using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradeShopApp.Models;

namespace TradeShopApp.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Category> Categories { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{

			var categories = new List<Category>()
			{
				new Category(){ CategoryId = 1, CategoryName = "Clothes"},
				new Category(){CategoryId = 2, CategoryName = "Shirts", ParentCategoryId = 1},
				new Category(){CategoryId = 3, CategoryName = "Hoodies", ParentCategoryId = 1},
				new Category(){ CategoryId = 4, CategoryName = "Electronics"},
				new Category(){CategoryId = 5, CategoryName = "Mobile Phones", ParentCategoryId = 4},
				new Category(){CategoryId = 6, CategoryName = "Computers", ParentCategoryId = 4},
				new Category(){CategoryId = 7, CategoryName = "TVs", ParentCategoryId = 4},
				new Category(){ CategoryId = 8, CategoryName = "Books"},
				new Category(){ CategoryId = 9, CategoryName = "Romance", ParentCategoryId=8},
				new Category(){ CategoryId = 10, CategoryName = "Fantasy", ParentCategoryId=8},
				new Category(){ CategoryId = 11, CategoryName = "Sci-Fi", ParentCategoryId=8},
			};
			builder.Entity<Category>().HasData(categories);
			base.OnModelCreating(builder);
		}
	}
}
