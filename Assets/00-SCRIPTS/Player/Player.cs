using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerLevel))]
public class Player : MonoBehaviour
{
    public static Player Instant { get; private set; }
    [Header("Components info")]
    public PlayerHealth playerHealth;
    public Rigidbody2D rb;
    public Collider2D cd;
    public Animator anim;
    private PlayerLevel playerLevel;
    public SpriteRenderer avatar;
    public Weapon activeWeapon;

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
        if (Instant != null && Instant != this)
        {
            Destroy(this);
        }
        else
        {
            Instant = this;
        }
        // if (Instance != null)
        rb = gameObject.GetComponent<Rigidbody2D>();
        cd = gameObject.GetComponent<Collider2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        avatar = transform.GetChild(0).GetComponent<SpriteRenderer>();


        stateMachine = new StateMachine();
        idleState = new IdleState(this, stateMachine, "Idle");
        moveState = new MoveState(this, stateMachine, "Move");

    }
    private void Start()
    {




        playerLevel = GetComponent<PlayerLevel>();
        playerHealth = GetComponent<PlayerHealth>();
        stateMachine.InitState(idleState);
    }
    // Update is called once per frame
    private void Update()
    {
   

        // transform.position=Random.insideUnitCircle
        FlipController(avatar.transform);
        stateMachine.state.Update();




    }



    public bool HasLevelUp()
    {
        return playerLevel.HasLevelUp();
    }

    public void TakeDamage(float _damage)
    {

        playerHealth.TakeDamage(_damage);
    }
    public Vector2 GetPosCenter()
    {
        return (Vector2)transform.position + cd.offset;
    }
    public void FlipController(Transform _avatar)
    {
        if (rb.velocity.x > 0)
        {
            _avatar.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            _avatar.localScale = new Vector3(-1, 1, 1);

        }
    }


}
