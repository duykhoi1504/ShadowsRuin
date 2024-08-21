using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelUpSelectionButton : MonoBehaviour
{
    public TextMeshProUGUI upgradeDescText, nameLevelText;
    public Image weaponIcon;
    private Weapon assignedWeapon;

    public Button button;

    private void Start()
    {
       

        button = GetComponent<Button>();
    }
    // private void Update() {
    //     if(isClicked){
    //         gameObject.SetActive(false);
    //     }
    // }
    public void UpdateButtonDisplay(Weapon _weapon)
    {
        upgradeDescText.color = Color.clear;

        if (_weapon.gameObject.activeSelf)
        {


            upgradeDescText.text = _weapon.stats[_weapon.levelWeapon].upgradeText;
            weaponIcon.sprite = _weapon.icon;
            nameLevelText.text = $"{_weapon.name} - Lvl {_weapon.levelWeapon + 1}";
        }
        else
        {

            upgradeDescText.color = Color.red;
            upgradeDescText.text = " Unblock " + _weapon.name;

            weaponIcon.sprite = _weapon.icon;
            nameLevelText.text = _weapon.name;
        }
        assignedWeapon = _weapon;
    }


    public void SelectUpgrade()
    {
       
        if (assignedWeapon != null)
        {

            if (assignedWeapon.gameObject.activeSelf)
            {
                assignedWeapon.levelUpWeapon();
            }
            else
            {
                PlayerManager.Instance.AddWeapon(assignedWeapon);

            }
        }
        UIManager.Instance.ShopContainer.SetActive(false);
        // GameManager.Instance.ChangeState(GameState.GAMEPLAY);
    }
}
