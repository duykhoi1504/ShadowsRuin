using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
//  [SerializeField] private IItemSlot item; // Assuming you have an Item class
    private IItemSlot itemSlot;

    private void Start() 
    {
        itemSlot = GetComponent<IItemSlot>();
        // if (itemSlot != null)
        // {
        //     item = itemSlot.item; // Lấy thông tin item từ ItemSlot
        // }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemSlot != null)
        {
            ToolTipManager.Instant.SetAndShowToolTip(itemSlot); // Hiển thị tooltip
        }
        Debug.Log("OnPointerEnter");
              // Vector3 trueView  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // trueView.z = 0;
        // transform.position =trueView;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipManager.Instant.HideToolTip(); // Ẩn tooltip
        Debug.Log("OnPointerEnter");

    }
}