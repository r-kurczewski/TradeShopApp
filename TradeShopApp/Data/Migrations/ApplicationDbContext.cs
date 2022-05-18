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
		private const string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.";
		private const string delivery = 
@"Shipping only to the USA and EU.
Standard Delivery (3-7 days): $10.50
Express Delivery: (1-3 days) $15.90";
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
					ShortDescription = "Great EyePhone 5 with etui, two colors available: red and white.",
					LongDescription = lorem,
					OfferDetails = delivery,
				},
				new Product()
				{
					ProductId = 2,
					CategoryId = 10,
					ProductName ="Whicher: The lady of the River",
					Price = 35.60M,
					Quantity = 1,
					ThumbnailPath = "https://data.europa.eu/sites/default/files/news/2020-08-06-edp_book_club.png",
					ShortDescription = "Great book based on even better game.",
					LongDescription = lorem,
					OfferDetails = delivery,
				},
				new Product()
				{
					ProductId = 3,
					CategoryId = 3,
					ProductName ="Black hoodie",
					Price = 15.60M,
					Quantity = 15,
					ThumbnailPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTb3I_38rtMgpNTapQ30tzsPJR03Oex6im7hg&usqp=CAU",
					ShortDescription = "Very stylish black hoodie.",
					LongDescription = lorem,
					OfferDetails = delivery,
				},

				new Product()
				{
					ProductId = 4,
					CategoryId = 7,
					ProductName ="TV FG",
					Price = 1629.99M,
					Quantity = 1,
					ThumbnailPath = "https://www.publicdomainpictures.net/pictures/70000/velka/tv-isolated-background-clipart.jpg",
					ShortDescription = @"Manufacturer: FG
									Screen diagonal: 32 inches(80 cm)
									Nominal resolution: 1366 x 768(HD Ready) pixels
									Implementation technology: LCD - LED",
					LongDescription = lorem,
					OfferDetails = delivery,
				},
			};
			builder.Entity<Product>().HasData(products);

			base.OnModelCreating(builder);
		}
	}
}
