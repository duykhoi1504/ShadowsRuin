using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : Singleton<PlayerDetection>
{
    // Start is called before the first frame update
    [SerializeField] CircleCollider2D playerCD;
    Player player;
    public float rangeCollect;

    void Start()
    {
        playerCD=transform.GetChild(2).GetComponent<CircleCollider2D>();
        player=Player.Instant;
        playerCD.radius=rangeCollect;
        // playerCD=transform.GetChild(3).GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<ICollectable>()!=null){
            //co the dung` if(other.TryGetComponent(out Exp exp))
            if(!other.IsTouching(playerCD))
                return;
            // Debug.Log("collected"+ exp.name);  
            other.GetComponent<ICollectable>().Collect(player); 
            // Destroy(other.gameObject);
        }
    }
}
