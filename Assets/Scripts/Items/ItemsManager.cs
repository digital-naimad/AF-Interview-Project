namespace AFSInterview.Items
{
	using TMPro;
	using UnityEngine;
	using UnityEngine.UIElements;

	public class ItemsManager : MonoBehaviour
	{
		[SerializeField] private InventoryController inventoryController;

		[Header("Items")]

        [Range(0.0F, 1000.0F)]
        [SerializeField] private int itemSellMaxValue;

		[SerializeField] private Transform itemSpawnParent;
		[SerializeField] private GameObject itemPrefab;
		[SerializeField] private BoxCollider itemSpawnArea;

		[Range(0.0F, 60.0F)]
		[SerializeField] private float itemSpawnInterval;


		[Header("UI elements")]

        [SerializeField] private TextMeshProUGUI moneyIndicatorLabel;
        [SerializeField] private string moneyLabelPrefix = "Money: ";

		[SerializeField] private ItemEquipPromptController itemEquipPrompt;
		[SerializeField] private InventoryPanelController inventoryPanel; 

        private float nextItemSpawnTime;

        #region Life-cycle methods

        private void Start()
		{
			moneyIndicatorLabel = FindObjectOfType<TextMeshProUGUI>();
        }

		private void Update()
		{
			if (Time.time >= nextItemSpawnTime)
				SpawnNewItem();
			
			if (Input.GetMouseButtonDown(0))
				TryPickUpItem();

			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (inventoryController.SellAllItemsUpToValue(itemSellMaxValue) > 0)
				{
					UpdateMoneyLabel();
				}
			}

			/*
            if (Input.GetKeyDown(KeyCode.I))
			{

			}
			*/
        }

        #endregion

        #region Public methods 

		public Item GetNewItem()
		{
			var newItemObject = CreateItem();
            var itemHolder = newItemObject.GetComponent<IItemHolder>();
            var newItem = itemHolder.GetItem(true);
            return newItem;
        }

		public void EquipItem(Item item)
		{
            inventoryController.AddItem(item);
        }

		public void SellItem(Item item)
		{
			inventoryController.SellItem(item);
		}

        #endregion 

        private void SpawnNewItem()
		{
			nextItemSpawnTime = Time.time + itemSpawnInterval;
			
			var spawnAreaBounds = itemSpawnArea.bounds;
			var position = new Vector3(
				Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
				0f,
				Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
			);

			CreateItem(position);
			//Instantiate(itemPrefab, position, Quaternion.identity, itemSpawnParent);
		}

        private GameObject CreateItem(Vector3 position = default)
        {
            return Instantiate(itemPrefab, position, Quaternion.identity, itemSpawnParent);

        }

        private void TryPickUpItem()
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			var layerMask = LayerMask.GetMask("Item");
			if (!Physics.Raycast(ray, out var hit, 100f, layerMask) || !hit.collider.TryGetComponent<IItemHolder>(out var itemHolder))
				return;
			
			var item = itemHolder.GetItem(true);

			if (item.IsConsumable)
			{
				//itemEquipPrompt.FullfillAndShowPrompt(item);
				SellItem(item);
			}
			else
			{
				EquipItem(item);
			}

            Debug.Log("Picked up " + item.Name + (item.IsConsumable ? " (consumable)" : "") + " with value of " + item.Value + " and now have " + inventoryController.ItemsCount + " items");
		}

		#region Private helper methods | TODO: move to the UI management class
		private void UpdateMoneyLabel()
		{
            moneyIndicatorLabel.text = moneyLabelPrefix + inventoryController.Money;
        }

        #endregion
    }
}