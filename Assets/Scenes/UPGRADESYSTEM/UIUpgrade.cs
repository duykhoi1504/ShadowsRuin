using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIUpgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Upgrade upgrade;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image image;

    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI costText;
     [SerializeField] Button button;
    private void OnEnable()
    {
        button.GetComponent<Button>().onClick.AddListener(()=>ClickUpgrade());
    }
    public void SetUpgrade(Upgrade _upgrade)
    {
        upgrade = _upgrade;
        image.sprite = upgrade.icon;
        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.description;
        costText.text = upgrade.baseCost.ToString();
    }

    public void SetCostTextColor()
    {
        costText.color = upgrade.baseCost > 40 ? Color.red : Color.white;
    }
    public void ClickUpgrade(){
         upgrade.DoUpgrade();
         
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
    //    upgrade.DoUpgrade();
    //    Debug.Log("pointtttt");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide details
    }
}