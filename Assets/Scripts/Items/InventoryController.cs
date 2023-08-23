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

		public void SellAllItemsUpToValue(int maxValue)
		{
            for (var iItem = items.Count - 1; iItem >= 0; iItem--)
            {
                var itemValue = items[iItem].Value;
                if (itemValue > maxValue)
                    continue;

                money += itemValue;
                items.RemoveAt(iItem);
            }

			//items.RemoveAll(item => item.Value <= maxValue);

            /* old solution
			for (var i = 0; i < items.Count; i++)
			{
				var itemValue = items[i].Value;
				if (itemValue > maxValue)
					continue;
				
				money += itemValue;
				items.RemoveAt(i);
			}
			*/
        }

		public void AddItem(Item item)
		{
			items.Add(item);
		}
	}
}