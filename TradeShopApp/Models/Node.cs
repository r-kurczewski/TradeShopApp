using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeShopApp.Models
{
	public partial class Node<T>
	{
		public List<Node<T>> children;
		public Node<T> parent;
		public T item;

		public Node(T item)
		{
			this.item = item;
		}

		public Node(T item, Node<T> parent)
		{
			this.item = item;
			this.parent = parent;
		}

		public static Node<T> GetTree<T>(List<T> items) where T : INodeItem
		{
			var root = new Node<T>(default);
			var categoryNodes = items.
				Select(c => new Node<T>(c))
				.ToList();
			var childsHash = categoryNodes.ToLookup(node => node.item.ParentId);

			foreach (var node in categoryNodes)
			{
				node.children = childsHash[node.item.Id].ToList();
			}
			root.children = categoryNodes
				.Where(c => !c.item.ParentId.HasValue)
				.ToList();
			return root;
		}
	}
}
