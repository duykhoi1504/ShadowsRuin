using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private float bulletSpeed = 10f;
    private float bulletDamage;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void shoot(float _damage, Vector2 _dir)
    {
        bulletDamage = _damage;
        transform.up = _dir;
        rigi.velocity = _dir * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
