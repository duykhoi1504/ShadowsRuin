using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [Header("Components info")]
    public PlayerHealth playerHealth;
    public Rigidbody2D rb;
    public Collider2D cd;

    
    [Header("Move info")]
    public float moveSpeed = 5f;

    #region Statemachine 
    public StateMachine stateMachine;
    public IdleState idleState;
    public MoveState moveState;
    #endregion
    // public MobileJoystick joyTick;
    public JoySticks joyStick1;

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
        // if (Instance != null)
        rb = gameObject.GetComponent<Rigidbody2D>();
        cd = gameObject.GetComponent<Collider2D>();
        stateMachine = new StateMachine();
        idleState = new IdleState(this, stateMachine);
        moveState = new MoveState(this, stateMachine);

    }
    private void Start()
    {
        playerHealth=GetComponent<PlayerHealth>();
        stateMachine.InitState(idleState);
    }

    // Update is called once per frame
    private void Update()
    {
        // transform.position=Random.insideUnitCircle

        stateMachine.state.Update();

    }
    public void TakeDamage(float _damage){
     
        playerHealth.TakeDamage(_damage);
    }


}
