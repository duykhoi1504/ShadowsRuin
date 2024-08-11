using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public enum State
    {
        Idle,
        Attack
    }
    private State state;
    [Header("Components info")]
    Animator anim;
    BoxCollider2D cd;
    [Header("Setting info")]
    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyMask;

    [Header("Elements info")]
    [SerializeField] private Transform hitCheck;
    [SerializeField] private float hitRadius;

    [Header("Attack info")]
    [SerializeField] private float AttackTimer;
    [SerializeField] private float attackDelay;

    [SerializeField] private float attackDamage;
    [SerializeField] private List<Enemy> damageEnemies = new List<Enemy>();
    [Header("Animations info")]
    [SerializeField] private float aimLerp;

    void Start()
    {
        anim=GetComponent<Animator>();
        cd=GetComponentInChildren<BoxCollider2D>();
        state=State.Idle;
    }

    // Update is called once per frame
    void Update()
    {

        switch(state){
            case State.Idle:
            AutoAim();
            break;
            case State.Attack:
            Attacking();
            break;
        }
        // AutoAim();
        // Attack();


    }


    [NaughtyAttributes.Button]
    public void StartAttack()
    {
        anim.Play("Attack");
    
         state=State.Attack;
        damageEnemies.Clear();
        anim.speed=1/attackDelay;
    }
    public void Attacking(){
        Attack();
    }
    public void StopAttack()
    {
         state=State.Idle;
        damageEnemies.Clear();
    }

    private void AutoAim()
    {
        Enemy enemyCloset = GetEnemyClosest();
        Vector2 targetUpVector = Vector3.up;


        if (enemyCloset != null)
        {
            targetUpVector = (enemyCloset.transform.position - transform.position).normalized;
            transform.up=targetUpVector;
            ManageAttackTimer();
        }
        // Quaternion newRotation = Quaternion.LookRotation(transform.forward, dir);
        // transform.rotation = newRotation;
        transform.up = Vector3.Lerp(transform.up, targetUpVector, Time.deltaTime * aimLerp);
        AttackTimer+=Time.deltaTime;
    }

    void ManageAttackTimer(){
        if(AttackTimer>=attackDelay){
            AttackTimer=0;
            StartAttack();
        }
    }

    private Enemy GetEnemyClosest()
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
    public void Attack()
    {
        // Collider2D[] enemies = Physics2D.OverlapCircleAll(hitCheck.position, hitRadius, enemyMask);
        Collider2D[] enemies = Physics2D.OverlapBoxAll(hitCheck.position, cd.bounds.size,hitCheck.localEulerAngles.z, enemyMask);

        foreach (var hit in enemies)
        {

            Enemy enemy = hit.GetComponent<Enemy>();
            if (!damageEnemies.Contains(enemy))
            {
                enemy.TakeDamage(attackDamage);
                damageEnemies.Add(enemy);
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

}
