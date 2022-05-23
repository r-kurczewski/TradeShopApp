using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public class MessagesViewModel
	{
		public List<Message> chatMessages;
		public List<Transaction> selling;
		public List<Transaction> buying;
	}
}
