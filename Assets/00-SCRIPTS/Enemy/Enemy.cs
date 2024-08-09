using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Components info")]
    Rigidbody2D rb;
    
    [Header("Move info")]

    public float moveSpeed = 3f;
    bool isChase;


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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);


    }
    void Start()
    {
    
        SetRenderersVisibility(true);
        stateMachine.InitState(idleState);


    }

    private void SetRenderersVisibility(bool visibility){
        spawnIndicator.enabled = visibility;
        enemySprite.enabled = !visibility;
    }
    // Update is called once per frame
    public void animIndicator(GameObject _gameObject)
    {
       
        LeanTween.scale(_gameObject, new Vector3(1, 1, 1), .2f)
                .setLoopPingPong(3)
                .setOnComplete(whenCompleteSpawn);
    }
    private void whenCompleteSpawn()
    {
        SetRenderersVisibility(false);
        isSpawned = true;
    }
    void Update()
    {
        // Debug.draw(this.transform.position,attackRadious);
     

        stateMachine.state.Update();
    }
    public void SetVelocity(Vector2 _Velocity)
    {
        rb.velocity = _Velocity;
    }
    void OnDrawGizmos()
    {
        // Vẽ một đường tròn với bán kính 2 tại vị trí của game object
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadious);
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, chaseRadious);

    }
    public void passAway()
    {
        passAwayPS.transform.SetParent(null);
        passAwayPS.Play();
        Destroy(gameObject);
    }

    public bool IsDetectPlayer()
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

}
