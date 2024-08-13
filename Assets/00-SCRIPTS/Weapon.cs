using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Start is called before the first frame update


    protected  SpriteRenderer sprite;

    [Header("Setting info")]
    [SerializeField] protected float range;
    [SerializeField] protected LayerMask enemyMask;

    [Header("Elements info")]
    // [SerializeField] protected Transform hitCheck;
  

    [Header("Attack info")]
    [SerializeField] protected float AttackTimer;
    [SerializeField] protected float attackDelay;

    [SerializeField] protected float attackDamage;
    [Header("Animations info")]
    [SerializeField] protected float aimLerp;

    protected virtual void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // AutoAim();
        // Attack();
    }
    protected virtual void AutoAim()
    {

    }
    protected Enemy GetEnemyClosest()
    {
        Enemy closetTarget = null;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);


        foreach (var enemy in enemies)
            Debug.Log(enemy.name);

        if (enemies.Length <= 0)
            return null;

        float minDistancel = range;

        foreach (var hit in enemies)
        {
            Enemy closetTargetChecked = hit.GetComponent<Enemy>();
            if (closetTargetChecked != null)
            {
                // float closetTargetDistance1 = (closetTargetChecked.transform.position - transform.position).magnitude;

                float closetTargetDistance = Vector2.Distance(closetTargetChecked.transform.position, transform.position);


                if (closetTargetDistance < minDistancel)
                {
                    closetTarget = closetTargetChecked;
                    minDistancel = closetTargetDistance;

                }
            }
        }
        return closetTarget;
    }

    protected virtual void OnDrawGizmos()
    {
        // Vẽ một đường tròn với bán kính 2 tại vị trí của game object
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
        // if (hitCheck == null)
        //     return;
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(hitCheck.transform.position, hitRadius);

    }

}
