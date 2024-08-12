using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float timeToStop = 4f;

    private float bulletDamage;

private void OnEnable() {
     StartCoroutine(SelfDestruct());
}
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
        // Debug.Log("shottttttttttttttttttttttttttttt" + _damage);
        bulletDamage = _damage;
        transform.up = _dir;
        rigi.velocity = _dir * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
      

            player.TakeDamage(bulletDamage);
            // Destroy(gameObject);
            gameObject.SetActive(false);
           
            // ObjectPooling_Manager<EnemyBullet>.Instant.ReturnObject(this);
        }
    }
    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(timeToStop);
        gameObject.SetActive(false);
        
    }
}
