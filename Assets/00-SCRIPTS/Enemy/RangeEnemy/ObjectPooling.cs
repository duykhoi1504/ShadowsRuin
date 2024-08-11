using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    // Start is called before the first frame update
       private static ObjectPooling _instant;
    public static ObjectPooling Instant => _instant;
  
    public float size=5f;

    public List<GameObject> gameObjects =new List<GameObject>();
    

    private void Awake()
    {
        if (_instant == null)
            _instant = this;
        if (_instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        // if(gameObjects.Count == 0){
        // for(int i=0;i<=size;i++){
        //     GameObject g2 =Instantiate(this.gameObject);
        //     g2.SetActive(false);
        //     gameObjects.Add(g2);
        // }
        // }
    }

    public GameObject GetObject(GameObject gob, Transform _transform)
    {
        foreach (var g in gameObjects)
        {
            if (g.activeSelf)
            {
                continue;

            }
            return g;
        }
        GameObject g2 = Instantiate(gob, _transform.position, quaternion.identity);
        gameObjects.Add(g2);
        return g2;
    }
}
