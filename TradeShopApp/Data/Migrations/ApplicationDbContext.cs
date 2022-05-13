using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradeShopApp.Models;

namespace TradeShopApp.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{

			var categories = new List<Category>()
			{
				new Category(){ CategoryId = 1, CategoryName = "Clothes"},
				new Category(){ CategoryId = 2, CategoryName = "Shirts", ParentCategoryId = 1},
				new Category(){ CategoryId = 3, CategoryName = "Hoodies", ParentCategoryId = 1},
				new Category(){ CategoryId = 4, CategoryName = "Electronics"},
				new Category(){ CategoryId = 5, CategoryName = "Mobile Phones", ParentCategoryId = 4},
				new Category(){ CategoryId = 6, CategoryName = "Computers", ParentCategoryId = 4},
				new Category(){ CategoryId = 7, CategoryName = "TVs", ParentCategoryId = 4},
				new Category(){ CategoryId = 8, CategoryName = "Books"},
				new Category(){ CategoryId = 9, CategoryName = "Romance", ParentCategoryId=8},
				new Category(){ CategoryId = 10, CategoryName = "Fantasy", ParentCategoryId=8},
				new Category(){ CategoryId = 11, CategoryName = "Sci-Fi", ParentCategoryId=8},
				new Category(){ CategoryId = 12, CategoryName = "Smartphones", ParentCategoryId=5},
			};
			builder.Entity<Category>().HasData(categories);

			var products = new List<Product>()
			{
				new Product()
				{
					ProductId = 1,
					CategoryId = 12,
					ProductName ="EyePhone 5",
					Price = 849.99M,
					Quantity = 2,
					ThumbnailPath = "https://upload.wikimedia.org/wikipedia/commons/c/c7/Two_iPhones_%281091302%29.jpg",
					Description = "Great EyePhone 5 with etui, two colors available: red and white.",
				},
				new Product()
				{
					ProductId = 2,
					CategoryId = 10,
					ProductName ="Whicher: The lady of the River",
					Price = 35.60M,
					Quantity = 1,
					ThumbnailPath = "https://data.europa.eu/sites/default/files/news/2020-08-06-edp_book_club.png",
					Description = "Great book based on even better game.",
				},
				new Product()
				{
					ProductId = 3,
					CategoryId = 3,
					ProductName ="Black hoodie",
					Price = 15.60M,
					Quantity = 15,
					ThumbnailPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTb3I_38rtMgpNTapQ30tzsPJR03Oex6im7hg&usqp=CAU",
					Description = "Very stylish black hoodie.",
				},

				new Product()
				{
					ProductId = 4,
					CategoryId = 7,
					ProductName ="TV FG",
					Price = 1629.99M,
					Quantity = 1,
					ThumbnailPath = "https://www.publicdomainpictures.net/pictures/70000/velka/tv-isolated-background-clipart.jpg",
					Description = @"Manufacturer: FG
									Screen diagonal: 32 inches(80 cm)
									Nominal resolution: 1366 x 768(HD Ready) pixels
									Implementation technology: LCD - LED",
				},
			};
			builder.Entity<Product>().HasData(products);

			base.OnModelCreating(builder);
		}
	}
}
