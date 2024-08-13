using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using Unity.Mathematics;
using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] DamageText DamageTextPrefab;
    private ObjectPool<DamageText> damageTextPool;
    private void Awake()
    {
        // Enemy.OnDamageTaken+=InstantiteDamageText;
        Enemy.OnDamageTaken += InstantiteDamageText;
    }
    private void OnDestroy()
    {
        Enemy.OnDamageTaken -= InstantiteDamageText;

    }
    void Start()
    {
        damageTextPool = new ObjectPool<DamageText>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private DamageText CreateFunc()
    {
        return Instantiate(DamageTextPrefab, transform);

    }
    private void ActionOnGet(DamageText damageText)
    {
        damageText.gameObject.SetActive(true);
    }
    private void ActionOnRelease(DamageText damageText)
    {
        damageText.gameObject.SetActive(false);

    }
    private void ActionOnDestroy(DamageText damageText)
    {
        Destroy(damageText.gameObject);
    }

    private void InstantiteDamageText(float _damage, Vector2 _transform)
    {
        DamageText damageTextInstance = damageTextPool.Get();

        Vector2 spawnTextPos = _transform + Vector2.up * 1.5f;
        damageTextInstance.transform.position = spawnTextPos;
        //    DamageText damageText= Instantiate(DamageTextPrefab,spawnText,quaternion.identity,transform);
        damageTextInstance.StartDamageText(_damage);
        LeanTween.delayedCall(4f, () => damageTextPool.Release(damageTextInstance));
    }
}
