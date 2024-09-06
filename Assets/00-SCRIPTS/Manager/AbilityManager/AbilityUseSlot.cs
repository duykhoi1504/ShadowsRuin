using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityUseSlot : MonoBehaviour
{
    [SerializeField] private Ability ability;

    [SerializeField] Image image => transform.GetChild(0).GetComponent<Image>();
    [SerializeField] Image cooldown => transform.GetChild(1).GetComponent<Image>();
    [SerializeField] TextMeshProUGUI text => transform.GetChild(2)?.GetComponent<TextMeshProUGUI>();


    public Ability Ability { get => ability; set => ability = value; }
    [SerializeField] private KeyCode keyCode;
    public Button button;
    [SerializeField] int timeCount;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UseAbilitySlot);

    }
    private void Update()
    {
        CoolDownUI();
        UseAbility();

//tesst max
    }
    private void UseAbility()
    {
        // Kiểm tra nếu phím được nhấn giữ
        if (Input.GetKey(keyCode))
        {
            if (ability.AbilityType == AbilityType.PushAway)
            {
                // Thực hiện OnButtonDown cho khả năng PushAway
                AbilityManager.Instant.OnButtonDown();

            }
            else
            {
                // Thực hiện khả năng khác (nếu cần thiết)
                UseAbilitySlot(); // hoặc gọi một phương thức khác cho các khả năng khác
            }
        }

        // Kiểm tra nếu phím được thả
        if (Input.GetKeyUp(keyCode))
        {
            if (ability.AbilityType == AbilityType.PushAway)
            {
                // Thực hiện OnButtonUp cho khả năng PushAway
                AbilityManager.Instant.OnButtonUp();
                UseAbilitySlot();
            }
            // Có thể không cần làm gì cho các khả năng khác khi thả phím
        }
    }
  public void CoolDownUI()
{
    if (ability)
    {
        // Enable or disable the cooldown UI based on cooldown status
        cooldown.enabled = ability.CoolDownTimer > 0;

        if (ability.CoolDownTimer > 0)
        {
            // Calculate the fill amount based on the remaining cooldown time
            cooldown.fillAmount = Mathf.Clamp01(ability.CoolDownTimer / ability.CoolDown);
        }
    }
}
    public void ConfgiAbilitySLot(Ability _ab)
    {

        ability = _ab;

        if (ability.AbilityType == AbilityType.PushAway)
        {
            EventTrigger ev = this.gameObject.AddComponent<EventTrigger>();
            // Add pointer down event
            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
            pointerDownEntry.callback.AddListener((data) => AbilityManager.Instant.OnButtonDown());
            ev.triggers.Add(pointerDownEntry);
            // Add pointer up event
            EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
            pointerUpEntry.callback.AddListener((data) => AbilityManager.Instant.OnButtonUp());
            ev.triggers.Add(pointerUpEntry);
        }
    }
    // public void UseAbility()
    // {
    //     // AbilityManager.Instant.UseAbility(ab);
    // }

    public void UseAbilitySlot()
    {
        AbilityManager.Instant.UseAbility(Ability);
    }
    public void UpgradeDisplayAbilityUse(Ability _ability)
    {
        ConfgiAbilitySLot(_ability);
        image.sprite = _ability.Image;
        if(text)
            text.text = _ability.name;
    }
}
