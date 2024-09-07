using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


[CreateAssetMenu(fileName ="Item Data", menuName ="Scriptable Objects/New Item Data",order =1)]

public class Item : ScriptableObject
{
    public string name;
    public int cost;

    public int quantity;
    public float value;

    public Sprite image;
    public ItemType itemType;

 
}

public enum ItemType{
    Postion,
    Speed,
}
