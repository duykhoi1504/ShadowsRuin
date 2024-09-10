using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipManager : Singleton<ToolTipManager>
{
    [SerializeField] Text name;
    [SerializeField] GameObject tool;

    [SerializeField] Text desc;
    [SerializeField] Image image;
    // [SerializeField] RectTransform canvas;
    // [SerializeField] Camera camera;

    private void Start()
    {
        // tool.gameObject.SetActive(false);
    }
    private void Update()
    {
        // Vector3 trueView = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // trueView.z = 0;
        //  tool.transform.position = trueView;
        // Vector2 screenPoint = Input.mousePosition;
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //     canvas.transform as RectTransform,
        //     screenPoint,
        //     camera,
        //     out Vector2 localPoint
        // );

        // transform.localPosition = localPoint;

    }
    public void SetAndShowToolTip(IItemSlot item)
    {
        //  tool.gameObject.SetActive(true);

        name.text = item.Name;
        desc.text = item.Description;
        image.sprite = item.Image;
    }
    // public void SetAndShowToolTip(Ability item)
    // {
    //     //  tool.gameObject.SetActive(true);

    //     name.text = item.name;
    //     desc.text = item.abilityStats[item.Level].description;
    //     image.sprite = item.Image;
    // }
    public void HideToolTip()
    {
        //  tool.gameObject.SetActive(false);
    }
}
