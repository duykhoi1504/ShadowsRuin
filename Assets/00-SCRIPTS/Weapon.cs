using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private Transform hitCheck;
    [SerializeField] private float hitRadius;


    [SerializeField] private float aimLerp;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AutoAim();
        Attack();

    }
    private void AutoAim()
    {
        Enemy enemyCloset = GetEnemyClosest();
        Vector2 targetUpVector = Vector3.up;


        if (enemyCloset != null)
            targetUpVector = (enemyCloset.transform.position - transform.position).normalized;

        // Quaternion newRotation = Quaternion.LookRotation(transform.forward, dir);
        // transform.rotation = newRotation;
            transform.up = Vector3.Lerp(transform.up, targetUpVector, Time.deltaTime * aimLerp );
    }
    private Enemy GetEnemyClosest()
    {
        Enemy closetTarget = null;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);
        foreach(var enemy in enemies)
            Debug.Log(enemy.name);
        
        if (enemies.Length <= 0)
            return null;

        float minDistancel = range;

        foreach (var hit in enemies)
        {
            Enemy closetTargetChecked = hit.GetComponent<Enemy>();
            if (closetTargetChecked != null)
            {
                float closetTargetDistance1 = (closetTargetChecked.transform.position - transform.position).sqrMagnitude;
                
                float closetTargetDistance = Vector2.Distance(closetTargetChecked.transform.position ,transform.position);
                Debug.Log(closetTargetDistance1 + "   "+closetTargetDistance);

                if (closetTargetDistance < minDistancel)
                {
                    closetTarget = closetTargetChecked;
                    minDistancel = closetTargetDistance;

                }
            }
        }
        return closetTarget;
    }
    void Attack(){
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, hitRadius, enemyMask);
        foreach (var hit in enemies)
        {
            if (hit.GetComponent<Enemy>() != null){
                hit.GetComponent<Enemy>().gameObject.SetActive(false);
            }
            
        }
    }
    void OnDrawGizmos()
    {
        // Vẽ một đường tròn với bán kính 2 tại vị trí của game object
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitCheck.transform.position, hitRadius);

    }
// private Enemy GetEnemyClosest()
// {
//     Enemy closestTarget = null;
//     Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);

//     if (enemies.Length <= 0)
//         return null;

//     float minDistance = range;

//     foreach (var hit in enemies)
//     {
//         Enemy enemyComponent = hit.GetComponent<Enemy>();
//         if (enemyComponent != null)
//         {
//             float distance = (enemyComponent.transform.position - transform.position).sqrMagnitude;
//             if (distance < minDistance)
//             {
//                 closestTarget = enemyComponent;
//                 minDistance = distance;
//             }
//         }
//     }

//     return closestTarget;
// }
}
