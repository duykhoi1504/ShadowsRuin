using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instant;

    public static T Instant
    {
        get
        {
            if (_instant == null)
            {
                _instant = FindObjectOfType<T>();
                if (_instant == null)
                {
                    Debug.LogWarning($"Instance of {typeof(T)} is needed in the scene, but there is none.");
                }
        
            }
            return _instant;
        }
    }

    protected virtual void Awake()
    {
        if (_instant != null && _instant != this)
        {
            Debug.LogWarning("Singleton already exists: " + _instant.gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            _instant = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
