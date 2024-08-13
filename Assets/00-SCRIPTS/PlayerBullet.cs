using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
        // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rigi;
 private float bulletSpeed = 10f;
    [SerializeField] private float timeToStop = 4f;


    [SerializeField] private LayerMask enemyMask;
    private float bulletDamage;
    private void OnEnable() {
     StartCoroutine(SelfDestruct());
}
    void Awake()
    {
            rigi = GetComponent<Rigidbody2D>();
    }

    public void shoot(float _damage,float _bulletSpeed, Vector2 _dir)
    {
        bulletSpeed = _bulletSpeed;
        bulletDamage = _damage;
        transform.up = _dir;
        rigi.velocity = _dir * bulletSpeed;
    }
    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(timeToStop);
        gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (IsPlayerDetected(other.gameObject.layer,enemyMask)){
        
            other.GetComponent<Enemy>().TakeDamage(bulletDamage);
            gameObject.SetActive(false);
        }
    }
    private bool IsPlayerDetected(int layer,LayerMask layerMask){

        return (layerMask.value & (1<<layer))!=0;
    }
}
