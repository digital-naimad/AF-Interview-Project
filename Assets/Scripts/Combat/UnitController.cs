using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] UnitAttribute[] unitAttributes;

        [SerializeField] private int maxHealthPoints;
        [SerializeField] private int currentHealthPoints;

        [SerializeField, Min(1)] private int attackInterval;

        [SerializeField] private int attackDamage;

        [SerializeField] private UnitAttribute additionalAtackAttribute;
        [SerializeField] private int additionallAttackDamage;

        public int CurrentHealthPoints => currentHealthPoints;
        public int turnOfLastAttack = -1;

        private void Awake()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SwitchEnableRaycast(bool isEnabled)
        {
            GetComponent<Collider>().enabled = isEnabled;
        }

        private void OnMouseDown()
        {
            Debug.Log("Mouse click");
           
        }

        
    }
}
