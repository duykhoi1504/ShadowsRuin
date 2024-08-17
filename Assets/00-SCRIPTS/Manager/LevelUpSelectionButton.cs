using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelUpSelectionButton : MonoBehaviour
{
    public TextMeshProUGUI upgradeDescText,nameLevelText;
    public Image weaponIcon;
    private  Weapon assignedWeapon;

    public void UpdateButtonDisplay(Weapon _weapon){
        if(_weapon.gameObject.activeSelf){

        
        upgradeDescText.text=_weapon.stats[_weapon.levelWeapon].ToString();
        weaponIcon.sprite=_weapon.icon;
        nameLevelText.text=_weapon.name + "- Lvl "+ _weapon.levelWeapon;
        }else{
           upgradeDescText.text= " Lvl "+ _weapon.name ;
           weaponIcon.sprite=_weapon.icon;
           nameLevelText.text=_weapon.name;
        }
        assignedWeapon=_weapon;
    }
    public void SelectUpgrade(){
        if(assignedWeapon!=null){
    
        if(assignedWeapon.gameObject.activeSelf){
assignedWeapon.levelUpWeapon();
        }else{
            Player.Instance.AddWeapon(assignedWeapon);

        }
            GameManager.Instance.ChangeState(GameState.GAMEPLAY);
        }
    }
}
