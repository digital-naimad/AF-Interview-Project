namespace AFSInterview.Items
{
	using System.Collections.Generic;
	using UnityEngine;

	public class InventoryController : MonoBehaviour
	{
		[SerializeField] private List<Item> items;
		[SerializeField] private int money;

		public int Money => money;
		public int ItemsCount => items.Count;

		/// <summary>
		/// Sells every item from the inventory which value is lower than max value given in the parameter.
		/// </summary>
		/// <param name="maxValue"></param>
		/// <returns>Returns additional amount of money added by this call if any (or 0).</returns>
		public int SellAllItemsUpToValue(int maxValue)
		{
			int cachedMoneyAmount = money;

            for (var iItem = items.Count - 1; iItem >= 0; iItem--)
            {
				if (items[iItem].Value <= maxValue)
				{
					SellItem(items[iItem]);
				}
            }

			return money - cachedMoneyAmount;
        }

		/// <summary>
		/// Adds item price (value) to the general amount of money.
		/// Also removes item from the inventory list
		/// </summary>
		/// <param name="itemToSell"></param>
		public void SellItem(Item itemToSell)
		{
			money += itemToSell.Value;

			if (items.Contains(itemToSell))
			{
				items.Remove(itemToSell);
			}
		}

		public void AddItem(Item item)
		{
			items.Add(item);
		}
	}
}