using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI upgradeValueText, upgradeNameText;
  
    [SerializeField] private  Image image;
    [field:SerializeField] public Button button  { get;  private set; }
    private void Awake() {
        button=this.GetComponent<Button>();
    }
    public void  ButtonUpgradeSetUp(Sprite icon, string valueText,string nameText){
        image.sprite=icon;
        upgradeValueText.text=valueText;
        upgradeNameText.text=nameText;
    }
}
