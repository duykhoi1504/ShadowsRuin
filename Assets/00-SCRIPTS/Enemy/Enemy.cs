using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// ushort System;
public class Enemy : MonoBehaviour
{

    [Header("Components info")]
    Rigidbody2D rb;
    [SerializeField] Collider2D cd;
    [SerializeField] private TextMeshPro textHealth;

    public static Action<float, Vector2> OnDamageTaken;

    [Header("Move info")]

    public float moveSpeed = 3f;
    bool isChase;

    [Header("Health info")]
    [SerializeField] private float maxHealth;
    private float health;


    [Header("Attack info")]

    public float attackRadious;
    public float chaseRadious;
    bool isAttack;
    public float attackDamage;
    [Header("Spawn info")]

    public bool isSpawned = false;

    public SpriteRenderer enemySprite;

    public SpriteRenderer spawnIndicator;
    public ParticleSystem passAwayPS;

    StateMachine stateMachine;
    public EnemyIdleState idleState;
    public EnemyChaseState chaseState;
    public EnemyAttackState attackState;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        stateMachine = new StateMachine();
        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);


    }
     protected virtual void Start()
    {

        health = maxHealth;
        SetRenderersVisibility(true);
        stateMachine.InitState(idleState);


    }

     protected virtual void SetRenderersVisibility(bool visibility)
    {
        spawnIndicator.enabled = visibility;
        enemySprite.enabled = !visibility;
    }
    // Update is called once per frame
    public virtual void animIndicator(GameObject _gameObject)
    {

        LeanTween.scale(_gameObject, new Vector3(1, 1, 1), .2f)
                .setLoopPingPong(3)
                .setOnComplete(whenCompleteSpawn);
    }
    protected virtual void whenCompleteSpawn()
    {
        SetRenderersVisibility(false);
        cd.enabled = true;
        isSpawned = true;
    }
    protected virtual void Update()
    {
        // Debug.draw(this.transform.position,attackRadious);
        textHealth.text = health.ToString();

        stateMachine.state.Update();
    }
    public virtual void SetVelocity(Vector2 _Velocity)
    {
        rb.velocity = _Velocity;
    }
     protected virtual void OnDrawGizmos()
    {
        // Vẽ một đường tròn với bán kính 2 tại vị trí của game object
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadious);
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, chaseRadious);

    }
    public virtual void passAway()
    {
        passAwayPS.transform.SetParent(null);
        passAwayPS.Play();
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public virtual void TakeDamage(float _damage)
    {
        health -= _damage;
        OnDamageTaken?.Invoke(_damage, this.transform.position);
        if (health <= 0)
        {
            passAway();
        }

    }
    public virtual bool IsDetectPlayer()
    {
        Collider2D[] attackCd = Physics2D.OverlapCircleAll(transform.position, chaseRadious);

        foreach (Collider2D hit in attackCd)
        {
            if (hit.GetComponent<Player>() != null)
            {
                return true;
            }
        }
        return false;
    }
    public Vector2 getEnemyDir(){
        Player player=Player.Instance;
        if(player==null) return Vector2.zero;
        return (player.transform.position-this.gameObject.transform.position).normalized;
    }
    public float getDistanceEtoP(){
        Player player=Player.Instance;
        if(player==null) return Mathf.Infinity;
        float distance=Vector2.Distance(this.gameObject.transform.position,player.transform.position);
        return distance;
    }
}
