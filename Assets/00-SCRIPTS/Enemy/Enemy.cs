using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;

    bool isChase;
    bool isAttack;
    StateMachine stateMachine;
    public EnemyIdleState idleState;
    public EnemyChaseState chaseState;
    public float moveSpeed = 3f;
    public float attackRadious;
    public float chaseRadious;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);

    }
    void Start()
    {
        stateMachine.InitState(idleState);
    }

    // Update is called once per frame
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
public bool IsDetectPlayer(){
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
