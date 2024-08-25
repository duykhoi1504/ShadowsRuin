using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : MonoBehaviour
{
    [SerializeField] private AbilityType abilityType;


    public void UpdgradeAbility()
    {
        AbilityManager.Instant.UpgradeAbilityStats(abilityType);
    }
}
