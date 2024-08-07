using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Rigidbody2D rb;
    public float moveSpeed = 3f;
    public float attackRadious;
    public float chaseRadious;
    bool isChase;
    bool isAttack;
    public bool isSpawned=false;

    [SerializeField] SpriteRenderer enemySprite;

    [SerializeField] SpriteRenderer spawnIndicator;
    public ParticleSystem passAwayPS;

    StateMachine stateMachine;
    public EnemyIdleState idleState;
    public EnemyChaseState chaseState;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);

    }
    void Start()
    {
        spawnIndicator.enabled=true;
        enemySprite.enabled = false;
        stateMachine.InitState(idleState);


    }

    // Update is called once per frame
    public void animIndicator(){
                SetVelocity(Vector2.zero);
        LeanTween.scale(spawnIndicator.gameObject, new Vector3(1, 1, 1), .3f)
                .setLoopPingPong(4)
                .setOnComplete(whenCompleteSpawn);
    }
    void whenCompleteSpawn()
    {
        spawnIndicator.enabled=false;
        enemySprite.enabled = true;
        isSpawned=true;

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
