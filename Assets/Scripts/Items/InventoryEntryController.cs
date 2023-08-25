using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AFSInterview
{
    public class InventoryEntryController : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI nameLabel;
        [SerializeField] private TextMeshProUGUI valueLabel;

        [Header("Buttons references")]

        [SerializeField]
        private Button sellButton;

        [SerializeField]
        private Button exchangeButton;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
