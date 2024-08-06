using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Collider2D cd;
    public StateMachine stateMachine;
    public IdleState idleState;
    public MoveState moveState;
    public MobileJoystick joyTick;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        if (Instance != null)
            rb = gameObject.GetComponent<Rigidbody2D>();
        cd = gameObject.GetComponent<Collider2D>();
        stateMachine = new StateMachine();
        idleState = new IdleState(this, stateMachine);
        moveState = new MoveState(this, stateMachine);

    }
    private void Start()
    {
        stateMachine.InitState(idleState);
    }

    // Update is called once per frame
    private void Update()
    {
        // transform.position=Random.insideUnitCircle

        stateMachine.state.Update();

    }


}
