using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public class Transaction
	{
		public int Id { get; set; }

		public ApplicationUser Buyer { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

		public TransactionState State { get; set; }


		public enum TransactionState { Pending, Canceled, Finished }

		#region Properties

		[NotMapped]
		public bool Selected { get; set; }

		#endregion
	}
}
