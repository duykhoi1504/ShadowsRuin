using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    [SerializeField] Animator anim;
    private void Start() {
        anim=GetComponent<Animator>();
    }
    public void beginShake(){
        anim.SetTrigger("Shake");
    }
}
