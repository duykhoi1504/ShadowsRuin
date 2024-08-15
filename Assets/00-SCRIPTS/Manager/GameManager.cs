using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


//         private static GameManager _instant;
//     public static GameManager Instance => _instant;

//     public EnemyBullet bulletPrefab;
//     public ObjectPooling<EnemyBullet> bulletPool;

//         public PlayerBullet playerBullet;
//     public ObjectPooling<PlayerBullet> playerbulletPool;

//   private void Awake()
//     {
//         if (_instant == null)
//             _instant = this;
//         if (_instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
//         {
//             Destroy(this.gameObject);
//         }
//     }

//     private void Start()
//     {
//      bulletPool=new ObjectPooling<EnemyBullet>(bulletPrefab,2,this.transform);
//      playerbulletPool=new ObjectPooling<PlayerBullet>(playerBullet,2,this.transform);
//     }
}
