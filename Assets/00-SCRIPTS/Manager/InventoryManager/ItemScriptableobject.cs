using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


[CreateAssetMenu(fileName ="Item Data", menuName ="Scriptable Objects/New Item Data",order =1)]

public class ItemScriptableobject : ScriptableObject
{
    public string name;
    public int quantity;
    public Sprite image;

    
}
