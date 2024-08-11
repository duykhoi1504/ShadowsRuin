using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  SpriteRenderer spriteRenderer;

    void Start()
    {
        // transformParent=GetComponentInParent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder=-(int)(transform.position.y*10);
    }
}
