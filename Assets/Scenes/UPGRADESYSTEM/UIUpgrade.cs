using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIUpgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Upgrade upgrade;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI costText;

    public void SetUpgrade(Upgrade _upgrade)
    {
        upgrade = _upgrade;
        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.description;
    }
    private void Start() {
     
    }
    public void SetCostTextColor()
    {
        costText.color = upgrade.baseCost > 0 ? Color.white : Color.red;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       upgrade.DoUpgrade();
       Debug.Log("pointtttt");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide details
    }
}