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
    [SerializeField] TextMeshProUGUI text => GetComponentInChildren<TextMeshProUGUI>();

    public Ability Ability { get => ability; set => ability = value; }

    public Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UseAbilitySlot);

    }
    public void ConfgiAbilitySLot(Ability _ab)
    {

        ability = _ab;
        
        if (_ab.AbilityType == AbilityType.PushAway)
        {
            EventTrigger ev = this.gameObject.AddComponent<EventTrigger>();
            // Add pointer down event
            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry{ eventID = EventTriggerType.PointerDown };
            pointerDownEntry.callback.AddListener((data) => AbilityManager.Instant.OnButtonDown());
            ev.triggers.Add(pointerDownEntry);
            // Add pointer up event
            EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry{ eventID = EventTriggerType.PointerUp };
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

        text.text = _ability.name;
        image.sprite = _ability.Image;
    }
}
