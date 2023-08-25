namespace AFSInterview.Items
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Item
	{
		[SerializeField] private string name;
		[SerializeField] private int value;
        [SerializeField] private bool isConsumable;

        public string Name => name;
		public int Value => value;

		public bool IsConsumable => isConsumable != null;

        public Item(string name, int value)
		{
			this.name = name;
			this.value = value;
		}

		public void Use()
		{
			Debug.Log("Using" + Name);
		}
	}
}