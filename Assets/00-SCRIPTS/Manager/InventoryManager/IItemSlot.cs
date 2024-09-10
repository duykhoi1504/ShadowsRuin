using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IItemSlot
{
     string Name { get; }
    string Description { get; }
    Sprite Image { get; }
}
