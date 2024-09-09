
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI quantity;
    [SerializeField] TextMeshProUGUI total;

    [SerializeField] int amount = 0;

    [SerializeField] Button buyButton;
    [SerializeField] Button plusButton;
    [SerializeField] Button minusButton;
    Item item;
    Ability abi;
    public StyleItem styleItem;
    void OnCompleteW()
    {
        quantity.color = Color.red;
        LeanTween.scale(quantity.gameObject, Vector3.one, .1f)
        .setDelay(.1f)
        .setEase(LeanTweenType.easeInOutCirc)
        .setOnComplete(() => quantity.color = Color.white);

    }
    private void Start()
    {
        styleItem=ShopManager.Instant.styleItem;
        amount = 0;
        plusButton.onClick.AddListener(() => PlusItems());
        minusButton.onClick.AddListener(() => MinusItems());
        buyButton.onClick.AddListener(() => BuyItem());

    }

    public void ConfigItem(Item _item)
    {
        item = _item;
        name.text = item.name;
        cost.text = item.cost.ToString();
        image.sprite = item.image;
        quantity.text = amount.ToString();

    }
    public void ConfigItem(Ability _abi)
    {
        abi = _abi;
        name.text = abi.Name;
        cost.text = abi.BaseCost.ToString();
        image.sprite = abi.Image;
        quantity.text = null;

    }
    public void BuyItem()
    {
        if (styleItem == StyleItem.Medicine)
        {
            if (GameManager.Instant.GameContentSO.Diamond < item.cost * amount)
            {
                LeanTween.scale(quantity.gameObject, Vector3.one * 2, .1f).setDelay(.1f).setEase(LeanTweenType.easeInBounce).setOnComplete(OnCompleteW);
            }
            else
            {
                if (GameManager.Instant.GameContentSO.Diamond <= 0)
                {
                    GameManager.Instant.GameContentSO.Diamond = 0;
                }
                else
                {

                    GameManager.Instant.GameContentSO.Diamond -= item.cost * amount;
                }
                InventoryManager.Instant.AddItem(item, amount);

            }
        }
        else if (styleItem == StyleItem.Ability)
        {
            if (GameManager.Instant.GameContentSO.Diamond < abi.BaseCost)
            {
                LeanTween.scale(quantity.gameObject, Vector3.one * 2, .1f).setDelay(.1f).setEase(LeanTweenType.easeInBounce).setOnComplete(OnCompleteW);
            }
            else
            {
                if (GameManager.Instant.GameContentSO.Diamond <= 0)
                {
                    GameManager.Instant.GameContentSO.Diamond = 0;
                }
                else
                {

                    GameManager.Instant.GameContentSO.Diamond -= abi.BaseCost;
                    abi.IsBuy=true;
                }
                AbilityManager.Instant.CheckIsBuy();
                 ShopManager.Instant.LoadItemAbility();
            }
        }

    }
    public void PlusItems()
    {
        amount++;
        quantity.text = amount.ToString();
        total.text = (amount * item.cost).ToString();
    }
    public void MinusItems()
    {
        if (amount <= 0)
        {
            amount = 0;
        }
        else
        {
            amount--;
        }
        quantity.text = amount.ToString();
        total.text = (amount * item.cost).ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        quantity.text = amount.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        quantity.text = amount.ToString();
    }
}
