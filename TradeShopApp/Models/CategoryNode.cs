using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
		public class CategoryNode
		{
			public Category category;
			public List<CategoryNode> nodes;

			public CategoryNode(Category category)
			{
				this.category = category;
			}
		}
	}
