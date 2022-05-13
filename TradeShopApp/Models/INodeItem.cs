namespace TradeShopApp.Models
{
		public interface INodeItem
		{
			public int Id { get; }
			public int? ParentId { get; }
		}
	}
