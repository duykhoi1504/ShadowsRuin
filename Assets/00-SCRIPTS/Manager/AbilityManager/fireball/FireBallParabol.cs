
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireBallParabol : MonoBehaviour
{

    private Color color;
    protected Vector3 start, target;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] public float duration, heightY;
    protected float time;

    [SerializeField] private TrailRenderer[] trails;
    [SerializeField] private SpriteRenderer[] sprites;
    // [SerializeField] private BulletMovement bulletMovement;


    [SerializeField] private Vector3? targetVec3;
    public Vector3? TargetPosition { get => targetVec3; set => targetVec3 = value; }

    float noiseY;
    protected event Action<FireBallParabol> onDestroy;
    public void Init(Vector3 start, Vector3 target, Action<FireBallParabol> onDestroy)
    {
        this.start = start;
        this.target = target;
        this.onDestroy += onDestroy;
    }
    public void SetUp()
    {
        // bulletMovement = GetComponent<BulletMovement>();
        trails = GetComponentsInChildren<TrailRenderer>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        noiseY=Random.Range(-5, 6);
        SetUp();
        time = 0;
        // RandomColorTrail();

    }

    public void Apply(Vector3 start, Vector3 end)
    {

        Vector3 previousPoint = transform.position;
        time += Time.deltaTime;
        if (time < duration)
        {

            float linearT = time / duration;
            float heightT = curve.Evaluate(linearT);
            float height = heightT * heightY*noiseY;

            transform.position = Vector3.Lerp(start, end, linearT) + new Vector3(0, height, 0);

            Vector3 direction = (transform.position - previousPoint).normalized;
            transform.up = direction;
        }
        else
        {
            Destruct();
        }
    }
    protected virtual void Update()
    {
        // bulletMovement.CheckDuration(duration, target);
        if (duration <= 0)
        {
            transform.position = target;
        }
        Apply(start, target);
    }

    //làm mới viên đạn sau khi va cham muc tieu
    protected void ResetBullet()
    {
        time = 0;
        transform.position = start;

        // sprite.enabled = true;
        foreach (var sprite in sprites)
        {
            sprite.enabled = true;
        }
    }


    //mỗi màu bắn ra sẽ là 1 màu trailrenderer khác nhau
    protected void RandomColorTrail()
    {
        color = Random.ColorHSV();
        foreach (var trail in trails)
        {
            trail.startColor = color;
            trail.endColor = color;
        }
    }

    protected void Destruct()
    {
        Debug.Log("BOOM, GET PLAYERIMPACT");
        Destroy(this.gameObject);
        // StartCoroutine(IEDestruct());
    }


    private IEnumerator IEDestruct()
    {
        foreach (var sprite in sprites)
        {
            sprite.enabled = false;
        }
        // Col.enabled = false;
        yield return new WaitForSeconds(2f);

        ResetBullet();

        onDestroy?.Invoke(this);
    }

}
