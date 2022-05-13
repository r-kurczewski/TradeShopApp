using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public string ProductName { get; set; }
		public ApplicationUser Owner { get; set; }
		public uint Quantity { get; set; }
		[Column(TypeName = "decimal(8,2)")]
		public decimal Price { get; set; }
		public string ThumbnailPath { get; set; }
		public string Description { get; set; }
	}
}
