using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// ushort System;
public class Enemy : MonoBehaviour
{
    Player player;
    EntityFX fx;
    [SerializeField] bool isKnocked = false;

    public float knockSpeed = 10f;


    [Header("Components info")]
    public Rigidbody2D rb;
    public Collider2D cd;
    public Animator anim;

    [SerializeField] private TextMeshPro textHealth;

    public static Action<float, Vector2, bool> OnDamageTaken;
    public static Action<Vector2> OnPassAway;


    [Header("Move info")]

    public float moveSpeed = 3f;
    bool isChase;

    [Header("Health info")]
    [SerializeField] private float maxHealth;
    private float health;


    [Header("Attack info")]

    public float attackRadious;
    public float duration;

    public float chaseRadious;
    bool isAttack;
    public float attackDamage;
    public float knockBackDuration;

    [Header("Spawn info")]
    public int scoreToAdd;
    public bool isSpawned = false;

    public SpriteRenderer enemySprite;
    public Transform enemyAvatar;


    public SpriteRenderer spawnIndicator;
    public ParticleSystem passAwayPS;

    StateMachine stateMachine;
    public EnemyIdleState idleState;
    public EnemyChaseState chaseState;
    public EnemyAttackState attackState;

    private void OnEnable()
    {
        
        knockSpeed = 10f;
        isKnocked = false;
        cd.enabled = false;
    }
    protected virtual void Awake()
    {
        anim            = GetComponentInChildren<Animator>();
        fx              = GetComponent<EntityFX>();
        rb              = GetComponent<Rigidbody2D>();
        cd              = GetComponent<Collider2D>();
        stateMachine    = new StateMachine();
        idleState       = new EnemyIdleState    (this, stateMachine, "idle");
        chaseState      = new EnemyChaseState   (this, stateMachine, "move");
        attackState     = new EnemyAttackState  (this, stateMachine, "attack");


    }
    protected virtual void Start()
    {
        knockSpeed = 10f;

        cd.enabled = false;
        player = Player.Instant;

        health = maxHealth;
        SetRenderersVisibility(true);
        stateMachine.InitState(idleState);
        // stateMachine.InitState(chaseState);
    

    }

    protected virtual void Update()
    {
        // Debug.draw(this.transform.position,attackRadious);

        FlipController(enemyAvatar);
        textHealth.text = health.ToString();

        stateMachine.currentState.Update();
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
    protected virtual void SetRenderersVisibility(bool visibility)
    {
        // cd.enabled = !visibility;
        spawnIndicator.enabled = visibility;
        enemySprite.enabled = !visibility;
    }
    public virtual void SetVelocity(Vector2 _Velocity)
    {
        if (isKnocked) return;
        rb.velocity = _Velocity;
    }
    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
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


        OnPassAway?.Invoke(transform.position);
        passAwayPS.transform.SetParent(null);
        passAwayPS.Play();
        // Destroy(gameObject);
        PlayerScore.Instant.AddScore(scoreToAdd);
        gameObject.SetActive(false);
    }

    public virtual void TakeDamage(float _damage, bool isCriticalHit, bool shouldKnockBack)
    {
        // Check if the game object is active before starting the coroutine
        if (gameObject.activeInHierarchy)
        {
            fx.StartCoroutine("FlashFX");
            if (shouldKnockBack)
                StartCoroutine("HitKnockBack");
        }
        health -= _damage;  
        AudioManager.Instant.PlayerSFXPitch(CONTANST.enemyhurt);

        OnDamageTaken?.Invoke(_damage, this.transform.position, isCriticalHit);
        if (health <= 0)
        {
            
            passAway();
     
        }

    }

    public IEnumerator HitKnockBack()
    {

        isKnocked = true;
        rb.velocity = getEnemyDir() * -knockSpeed;
        yield return new WaitForSeconds(knockBackDuration);
        isKnocked = false;

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
    public Vector2 getEnemyDir()
    {
        Player player = Player.Instant;
        if (player == null) return Vector2.zero;
        return (player.GetPosCenter() - (Vector2)this.gameObject.transform.position).normalized;
    }
    public float getDistanceEtoP()
    {
        Player player = Player.Instant;
        if (player == null) return Mathf.Infinity;
        float distance = Vector2.Distance(this.gameObject.transform.position, player.GetPosCenter());
        return distance;
    }
    public virtual void attack()
    {
        Player.Instant.TakeDamage(attackDamage);
    }
    public virtual void FlipController(Transform _transform)
    {
         if (player)
    {
        // Debug.Log($"Player X: {player.transform.position.x}, Enemy X: {transform.position.x}");
        Vector3 scale = _transform.localScale;
        scale.x = player.transform.position.x > transform.position.x ? 1 : -1;
        _transform.localScale = scale;
    }
    }
}
