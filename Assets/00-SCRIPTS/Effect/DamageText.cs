using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Animator anim;
    [SerializeField] TextMeshPro textMP;
    
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    [NaughtyAttributes.Button]
    public void StartDamageText(float _damage){

        anim.Play("Animate");
       textMP.text="-"+ _damage.ToString();
    }
    public void StopFLoating(){
        this.gameObject.SetActive(false);
        
    }
}
