using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AFSInterview.Items
{
    public class ItemEquipPromptController : MonoBehaviour
    {
        [SerializeField] private string itemNameTextPrefix = "Item: ";

        [SerializeField] private string itemValueTextPrefix = "Value: ";

        [SerializeField] private TextMeshProUGUI itemNameLabel;

        [SerializeField] private TextMeshProUGUI itemValueLabel;

        [Header("Buttons references")]
        [SerializeField] private Button equipButton;

        [SerializeField] private Button sellButton;

        [SerializeField] private Button exchangeButton;

        private Item shownItem;


        public void FullfillAndShowPrompt(Item itemToShow)
        {
            shownItem = itemToShow;

            itemNameLabel.text = itemNameTextPrefix + itemToShow.Name;
            itemValueLabel.text = itemValueTextPrefix + itemToShow.Value;

            // Shows/hides buttons 
            equipButton.gameObject.SetActive(!itemToShow.IsConsumable);
            sellButton.gameObject.SetActive(itemToShow.IsConsumable);
            exchangeButton.gameObject.SetActive(itemToShow.IsConsumable);

            ShowPrompt();
        }

        public void ShowPrompt()
        {
            gameObject.SetActive(true);
        }

        public void HidePrompt()
        {
            gameObject.SetActive(false);
        }

        public void OnSellButtonClicked()
        {

        }

        public void OnEquipButtonClicked()
        {

        }

        public void OnExchangeButtonClicked()
        {
            
        }
    }
}
