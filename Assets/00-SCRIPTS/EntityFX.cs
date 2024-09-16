using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    Material originMat;
    [SerializeField] private Material hitFXMat;
    [SerializeField] private float FlashDuration;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        originMat =sprite.material;
        
    }

    // Update is called once per frame
   private IEnumerator FlashFX()
    {
        sprite.material = hitFXMat;
        yield return new WaitForSeconds(FlashDuration);
        sprite.material = originMat;

    }
    // private void RedColorBlink(){
    //     if(sprite.color!=Color.white){
    //         sprite.color = Color.white;
    //     }else
    //         sprite.color = Color.red;

    // }
    // private void CancelRedBlink(){
    //     CancelInvoke();
    //     sprite.color = Color.white;
    // }
}
