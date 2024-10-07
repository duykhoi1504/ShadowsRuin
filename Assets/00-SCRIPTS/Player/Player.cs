using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerLevel))]
public class Player : MonoBehaviour
{
    public static Player Instant { get; private set; }
    public Vector3 Mouse { get => mouse; set => mouse = value; }

    [Header("Components info")]
    public PlayerHealth playerHealth;
    public Rigidbody2D rb;
    public Collider2D cd;
    public Animator anim;
    private PlayerLevel playerLevel;
    public SpriteRenderer avatar;
    public Weapon activeWeapon;

    [Header("Move info")]
    private float xInput;
    // private float yInput;
    public float moveSpeed = 5f;

    public float dashSpeed = 5f;
    public float dashDuration = .5f;

    public Vector3 currentDir;

    #region Statemachine 
    public StateMachine stateMachine;
    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerDashState dashState;

    #endregion
    // public MobileJoystick joyTick;
    public JoySticks joyStick1;
    public bool isBusy;
    private Vector3 mouse;


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
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        dashState = new PlayerDashState(this, stateMachine, "Move");



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
        // xInput = Input.GetAxisRaw("Horizontal");
        // yInput = Input.GetAxisRaw("Vertical");
        // rb.velocity = new Vector3(xInput, yInput).normalized * moveSpeed;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        if (getDir() != Vector2.zero)
        {
            currentDir = getDir();
        }
        // transform.position=Random.insideUnitCircle
        FlipController(avatar.transform);
        stateMachine.currentState.Update();
    }
    public IEnumerator BusyFor(float seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(seconds);
        isBusy = false;
    }
    public Vector2 getDir()
    {
        // Vector2 dir = new Vector2(rb.velocity.x, rb.velocity.y);


        Vector2 dir = (Mouse - transform.position).normalized;
        return dir;
        // return joyStick1.GetMoveVector().normalized;

    }
    #region Velocity
    public void SetZeroVelocity()
    {
        // if(isKnocked){return;}
        rb.velocity = new Vector2(0, 0);
    }
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        // if(isKnocked){return;}

        rb.velocity = new Vector2(_xVelocity, _yVelocity);

    }


    #endregion
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
