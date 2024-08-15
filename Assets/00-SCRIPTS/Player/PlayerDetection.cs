using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Collider2D playerCD;
    Player player;

    void Start()
    {
        player=Player.Instance;
        playerCD=transform.GetChild(3).GetComponent<Collider2D>();
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
