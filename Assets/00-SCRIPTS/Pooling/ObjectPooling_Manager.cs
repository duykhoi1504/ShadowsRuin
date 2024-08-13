using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//tạo 1 GameObject trong scene
// public class BulletPool : ObjectPooling_Manager<EnemyBullet>{}
//=> dùng :
    //   EnemyBullet _bullet = ObjectPooling_Manager<EnemyBullet>.Instant.GetObject();
    //     _bullet.transform.position = transform.position;
    //     _bullet.transform.rotation = transform.rotation;
    //     _bullet.shoot(attackDamage, getEnemyDir());
    //      _bullet.gameObject.SetActive(true);
public class ObjectPooling_Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static ObjectPooling_Manager<T> _instant;
    public static ObjectPooling_Manager<T> Instant => _instant;

    [SerializeField] private T Obj_prefab;
    [SerializeField] private List<T> List_obj = new List<T>();

  private void Awake()
    {
        if (_instant == null)
            _instant = this;
        if (_instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

     public T GetObject()
    {
        foreach (T obj in List_obj)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        T newObject = Instantiate(Obj_prefab, transform);
        List_obj.Add(newObject);
        return newObject;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
