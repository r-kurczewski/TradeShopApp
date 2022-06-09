using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeShopApp.Models
{
	public class Product
	{
		public int ProductId { get; set; }

		public int CategoryId { get; set; }

		public Category Category { get; set; }

		[MinLength(5)]
		[Display(Name = "Product name")]
		public string ProductName { get; set; }

		public string OwnerId { get; set; }

		public ApplicationUser Owner { get; set; }

		public uint Quantity { get; set; }

		[Column(TypeName = "decimal(8,2)")]
		public decimal Price { get; set; }

		[Display(Name = "Thumbnail path")]
		public string ThumbnailPath { get; set; }

		[Display(Name = "Short description")]
		[MaxLength(180)]
		public string ShortDescription { get; set; }

		[Display(Name = "Long description")]
		public string LongDescription { get; set; }

		[Display(Name = "Offer details")]
		public string OfferDetails { get; set; }

		[Display(Name ="Item photo")]
		[NotMapped]
		public IFormFile UploadedPhoto { get; set; }
	}
}
