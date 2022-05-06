using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		[MaxLength(30)]
		public string CategoryName { get; set; }
		public int? ParentCategoryId { get; set; }
		public Category ParentCategory { get; set; }
	}
}
