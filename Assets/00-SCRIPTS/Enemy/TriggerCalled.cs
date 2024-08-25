using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCalled : MonoBehaviour
{
    private Enemy enemy => GetComponentInParent<Enemy>();
    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
    // private void AnimationPassAway()
    // {
    //     enemy.passAway();
    // }
}
