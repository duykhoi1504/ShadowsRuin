using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Quest")]

public class Quest : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string desc;

    [SerializeField] private Image image;


    [SerializeField] private int questGoal;
    // [SerializeField] private int gold;
    [SerializeField] private int diamond;


    [SerializeField] private List <ItemReWard> reward;

    public string Name { get => name; set => name = value; }
    public string Desc { get => desc; set => desc = value; }
    public Image Image { get => image; set => image = value; }

    public int QuestGoal { get => questGoal; set => questGoal = value; }
    public int Diamond { get => diamond; set => diamond = value; }
    public List<ItemReWard> Reward { get => reward; set => reward = value; }
}
[System.Serializable]
public struct ItemReWard{
    public Item item;
    public int quantity;
}