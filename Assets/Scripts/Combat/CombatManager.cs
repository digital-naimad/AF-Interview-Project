using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class CombatManager : MonoBehaviour
    {
        public enum TurnSide { FirstArmy, SecondArmy }
        public enum CombatState { AttackerSelection, OpponentSelection, DamageDeal}

        [SerializeField] UnitController[] firstArmyArray;
        [SerializeField] UnitController[] secondArmyArray;

        [SerializeField] UnitController[,] armies;

        [SerializeField] Transform firstArmyContainer;
        [SerializeField] Transform secondArmyContainer;

        [SerializeField] UnitController attackerUnit;
        [SerializeField] UnitController opponentUnit;

        private int turnCounter;

        #region Life-cycle methods

        // Start is called before the first frame update
        void Start()
        {
            firstArmyArray = firstArmyContainer.GetComponentsInChildren<UnitController>();
            secondArmyArray = secondArmyContainer.GetComponentsInChildren<UnitController>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        #endregion

        public void OnStartCombatButton()
        {
            turnCounter = Random.Range(0, 100) > 50 ? 0 : 1;

            EnableAttackerUnitSelection();
        }

        public void EnableAttackerUnitSelection()
        {
            DisableAllUnitsSelection();

            foreach (UnitController unit in (turnCounter % 2 == 0 ? firstArmyArray : secondArmyArray))
            {
                // TODO: implement checking of attack interval of the unit
                unit.SwitchEnableRaycast(true);
            }
        }

        public void EnableOpponentUnitSelection()
        {
            DisableAllUnitsSelection();

            foreach (UnitController unit in (turnCounter % 2 == 1 ? firstArmyArray : secondArmyArray))
            {
                unit.SwitchEnableRaycast(true);
            }
        }

        public void DisableAllUnitsSelection()
        {
            foreach (UnitController unit in firstArmyArray)
            {
                unit.SwitchEnableRaycast(false);
            }
        }

    }
}
