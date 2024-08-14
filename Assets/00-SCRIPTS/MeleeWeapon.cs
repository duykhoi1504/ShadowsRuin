using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    // Start is called before the first frame update
    [Header("Components info")]
    protected Animator anim;
    protected BoxCollider2D cd;
    [SerializeField] protected Transform HitDetectTransform;

    public enum State
    {
        Idle,
        Attack
    }
    private State state;
    [SerializeField] List<Enemy> damageEnemies = new List<Enemy>();

     protected override  void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        cd = GetComponentInChildren<BoxCollider2D>();

        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                // sprite.enabled=false;
                AutoAim();
                break;
            case State.Attack:
                // sprite.enabled=true;

                Attacking();
                break;
        }
    }

    protected override void AutoAim()
    {
        Enemy enemyCloset = GetEnemyClosest();
        Vector2 targetUpVector = Vector3.up;


        if (enemyCloset != null)
        {
            targetUpVector = (enemyCloset.transform.position - transform.position).normalized;
            transform.up = Vector3.Lerp(transform.up, targetUpVector, Time.deltaTime * aimLerp);
            ManageAttackTimer();
        }
        // Quaternion newRotation = Quaternion.LookRotation(transform.forward, dir);
        // transform.rotation = newRotation;
        transform.up = Vector3.Lerp(transform.up, targetUpVector, Time.deltaTime * aimLerp);
        AttackTimer += Time.deltaTime;
    }
    public void Attack()
    {
        // Collider2D[] enemies = Physics2D.OverlapCircleAll(hitCheck.position, hitRadius, enemyMask);
        Collider2D[] enemies = Physics2D.OverlapBoxAll(HitDetectTransform.position, cd.bounds.size, HitDetectTransform.localEulerAngles.z, enemyMask);

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

    public void StopAttack()
    {
        state = State.Idle;
        damageEnemies.Clear();
    }
    public void StartAttack()
    {
        anim.Play("Attack");

        state = State.Attack;
        damageEnemies.Clear();
        anim.speed = 1 / attackDelay;
    }
    protected void Attacking()
    {
        Attack();
    }
    protected virtual void ManageAttackTimer()
    {
        if (AttackTimer >= attackDelay)
        {
            AttackTimer = 0;
            StartAttack();
        }
    }
    // protected override void OnDrawGizmos()
    // {   
    //      Gizmos.color = Color.red;
    //         Gizmos.matrix = Matrix4x4.TRS(HitDetectTransform.position, Quaternion.Euler(0f, 0f, HitDetectTransform.localEulerAngles.z), Vector3.one);
    //         Gizmos.DrawWireCube(Vector3.zero, cd.bounds.size);
    // }
}
