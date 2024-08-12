using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

//khoi tao: 
    // ObjectPooling<EnemyBullet> bulletPool;
//trong hàm start
    // bulletPool = new ObjectPooling<EnemyBullet>(bullet, 3, transform);

//==============================
    //  EnemyBullet _bullet = bulletPool.GetObject();
        // _bullet.transform.position = transform.position;
        // _bullet.transform.rotation = transform.rotation;
        // _bullet.shoot(attackDamage, getEnemyDir());
//==============================
public class ObjectPooling<T>:MonoBehaviour  where T : MonoBehaviour
{
    
     private List<T> objectPool;
    private T objectPrefab;
    private Transform parentTransform;

    public ObjectPooling(T prefab, int initialSize, Transform parent = null)
    {
        objectPrefab = prefab;
        parentTransform = parent;
        objectPool = new List<T>();
        
        for (int i = 0; i < initialSize; i++)
        {
            T newObj = Instantiate(objectPrefab, parentTransform);
            newObj.gameObject.SetActive(false);
            objectPool.Add(newObj);
        }
    }

    public T GetObject()
    {
        foreach (T obj in objectPool)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        T newObject = Instantiate(objectPrefab, parentTransform);
        objectPool.Add(newObject);
        return newObject;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
