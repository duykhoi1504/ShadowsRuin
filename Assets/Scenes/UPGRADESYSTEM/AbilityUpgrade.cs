using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Ability Upgrade")]
public class AbilityUpgrade : Upgrade
{
    public string scriptName;
    public override void DoUpgrade()
    {
        // statsUpgrade.level = 1;
        var ability = FindObjectOfType(System.Type.GetType(scriptName)) as MonoBehaviour;
        if (ability != null)
        {
            // ability.gameObject.SetActive(true);
            ability.enabled = true;
        }else{
            Debug.Log("name ability "+scriptName);
        }
    }
    
}