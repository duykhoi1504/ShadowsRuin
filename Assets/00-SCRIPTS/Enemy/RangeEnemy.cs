using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeEnemy : Enemy
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
   protected override void Update()
    {
        base.Update();

    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if(getDistanceEtoP()<attackRadious){
        Gizmos.color=Color.white;
        Gizmos.DrawLine(transform.position,(Vector2)transform.position+getEnemyDir()*5);
        }
    }
}
