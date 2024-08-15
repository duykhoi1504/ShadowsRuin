using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Exp : DroppableBase
{
   public static Action<Exp> onCollected;
   protected override void Collected(){
    base.Collected();
    onCollected?.Invoke(this);
   }

}
