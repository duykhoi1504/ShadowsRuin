
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
    public void BuyItem()
    {
        if (PlayerCoin.Instant.CurrenDiamond < item.cost * amount)
        {
            LeanTween.scale(quantity.gameObject, Vector3.one * 2, .1f).setDelay(.1f).setEase(LeanTweenType.easeInBounce).setOnComplete(OnCompleteW);
        }
        else
        {
            if (PlayerCoin.Instant.CurrenDiamond <= 0)
            {
                PlayerCoin.Instant.CurrenDiamond = 0;
            }
            else
            {

                PlayerCoin.Instant.CurrenDiamond -= item.cost * amount;
            }
            InventoryManager.Instant.AddItem(item, amount);

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
