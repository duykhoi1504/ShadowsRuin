using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LeanTweenManager : MonoBehaviour
{
    [Header("MoveY")]
    [SerializeField] bool canBouce = false;
    public AnimationCurve curve;
    [SerializeField] float floatAmplitude;
    [SerializeField] float duration;
    [SerializeField] float delay;
    [SerializeField] bool canScale = false;
    public LeanTweenType easeType;
    [Header("Scale")]
        [SerializeField] float durationScale;
    [SerializeField] float delayScale;
    public LeanTweenType inType;
    public LeanTweenType outType;
    public UnityEvent onComPleteCallBack;




    void OnEnable()
    {
        if (canBouce)
        {
            if (easeType == LeanTweenType.animationCurve)
                LeanTween.moveY(gameObject, transform.position.y + floatAmplitude, duration).setDelay(delay).setLoopPingPong().setEase(curve);

            else
                LeanTween.moveY(gameObject, transform.position.y + floatAmplitude, duration).setDelay(delay).setLoopPingPong().setEase(easeType);

        }
         if (canScale){
            transform.localScale=Vector3.zero;
            LeanTween.scale(gameObject,Vector3.one,durationScale)
                .setDelay(delayScale)
                .setEase(inType)
                .setOnComplete(OnComplete);
         }
    }
    public void OnClose(){
        LeanTween.scale(gameObject,Vector3.zero,durationScale)
                .setDelay(delayScale)
                .setEase(outType)
                .setOnComplete(()=>gameObject.SetActive(false));
    }
    public void OnComplete(){
        if(onComPleteCallBack!=null){
            onComPleteCallBack.Invoke();
        }
    }
 


}
