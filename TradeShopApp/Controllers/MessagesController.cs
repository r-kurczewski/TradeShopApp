using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeShopApp.Data;
using TradeShopApp.Models;
using static TradeShopApp.Models.Transaction;

namespace TradeShopApp.Controllers
{
	public class MessagesController : Controller
	{
		private ApplicationDbContext context;
		private UserManager<ApplicationUser> userManager;

		public MessagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			this.context = context;
			this.userManager = userManager;
		}

		public async Task<IActionResult> Index([FromRoute] int? id)
		{
			var user = await userManager.GetUserAsync(User);
			var transaction = context.Transactions
				.Include(x => x.Buyer)
				.Include(x => x.Product)
				.Include(x => x.Product.Owner)
				.FirstOrDefault(x => x.Id == id);
			if (id.HasValue && transaction == null)
			{
				return NotFound();
			}
			else if (transaction != null && user != transaction?.Buyer && user != transaction?.Product?.Owner)
			{
				return Forbid();
			}
			var model = new MessagesViewModel();

			model.selling = context.Transactions
				.Include(x => x.Buyer)
				.Include(x => x.Product)
				.Include(x => x.Product.Owner)
				.Where(x => x.Product.Owner == user)
				.ToList();

			model.buying = context.Transactions
				.Include(x => x.Buyer)
				.Include(x => x.Product)
				.Include(x => x.Product.Owner)
				.Where(x => x.Buyer == user)
				.ToList();

			model.chatMessages = context.Messages
				.Where(x => x.Transaction.Id == id)
				.OrderBy(x => x.SentDate)
				.ToList();

			if(transaction != null)
			{
				transaction.Selected = true;
			}
			return View(model);
		}

		[ActionName("New")]
		public async Task<IActionResult> NewChat([FromRoute] int id)
		{
			var user = await userManager.GetUserAsync(User);
			var product = context.Products
				.Include(x => x.Owner)
				.FirstOrDefault(x => x.ProductId == id);
			if (product.Owner == user) return BadRequest();

			var transaction = new Transaction()
			{
				ProductId = id,
				Buyer = await userManager.GetUserAsync(User),
				State = TransactionState.Pending,
			};
			context.Transactions.Add(transaction);
			context.SaveChanges();
			return RedirectToAction("Index", transaction.Id);
		}

		[HttpPost]
		[ActionName("Index")]
		public async Task<IActionResult> NewMessage([FromRoute] int id, [FromForm] string message)
		{
			var user = await userManager.GetUserAsync(User);
			var transaction = context.Transactions
				.Include(x => x.Buyer)
				.Include(x => x.Product)
				.Include(x => x.Product.Owner)
				.FirstOrDefault(x => x.Id == id);

			if (transaction == null)
			{
				return NotFound();
			}
			else if (user != transaction.Buyer && user != transaction.Product.Owner)
			{
				return Forbid();
			}
			var msg = new Message();
			msg.Transaction = transaction;
			msg.ToSeller = transaction.Buyer == user;
			msg.SentDate = DateTime.Now;
			msg.Content = message;
			context.Messages.Add(msg);
			context.SaveChanges();
			return RedirectToAction("Index", id);
		}
	}
}
