using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerLevel))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
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
    [Header("Weapons info")]


    public List<GameObject> unAssignedWeapons, assignedwWeapons;
    public Transform weaponsParent;
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
        anim = transform.GetChild(0).GetComponent<Animator>();
        avatar = transform.GetChild(0).GetComponent<SpriteRenderer>();
        stateMachine = new StateMachine();
        idleState = new IdleState(this, stateMachine, "Idle");
        moveState = new MoveState(this, stateMachine, "Move");

    }
    private void Start()
    {
        SetUpUnAssignedWeapons();
        AddWeapon(Random.Range(0,unAssignedWeapons.Count));
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

    public void AddWeapon(int indexRand){
        if(indexRand <unAssignedWeapons.Count){
            assignedwWeapons.Add(unAssignedWeapons[indexRand]);
            unAssignedWeapons[indexRand].gameObject.SetActive(true);
            unAssignedWeapons.RemoveAt(indexRand);
        }
    }
      public void AddWeapon(Weapon weaponToAdd){
     
            weaponToAdd.gameObject.SetActive(true);
            assignedwWeapons.Add(weaponToAdd.gameObject);
            unAssignedWeapons.Remove(weaponToAdd.gameObject);
        
    }
    void SetUpUnAssignedWeapons()
    {
        unAssignedWeapons = new List<GameObject>();

        foreach (Transform weapon in weaponsParent)
        {
            unAssignedWeapons.Add(weapon.gameObject);
        }
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
