using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public class Message
	{
		public int Id { get; set; }

		public Transaction Transaction { get; set; }

		public string Content { get; set; }

		public bool ToSeller { get; set; }

		public DateTime SentDate { get; set; }

		#region Properties

		[NotMapped]
		public ApplicationUser Author => ToSeller ? Transaction?.Buyer : Transaction?.Product?.Owner;

		#endregion

	}
}
