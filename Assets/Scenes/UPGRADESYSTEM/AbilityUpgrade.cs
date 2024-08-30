using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Ability Upgrade")]
public class AbilityUpgrade : Upgrade
{
    public string scriptName;

    public override void DoUpgrade()
    {
        var ability = FindObjectOfType(System.Type.GetType(scriptName)) as MonoBehaviour;
        if (ability != null)
        {
            ability.enabled = true;
        }else{
            Debug.Log("name ability "+scriptName);
        }
    }
}