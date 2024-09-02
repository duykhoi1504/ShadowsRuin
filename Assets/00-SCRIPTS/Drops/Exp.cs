using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Exp : DroppableBase
{
   public static Action<Exp> onCollectedEXP;
   protected override void Collected()
   {
      base.Collected();
      AudioManager.Instant.SFXVolumn(.5f);

      AudioManager.Instant.PlaySFX(CONTANST.pickupcoin);
      onCollectedEXP?.Invoke(this);
   }

}
