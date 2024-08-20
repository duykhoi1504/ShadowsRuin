using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
    {

        private static T _instant = null;
        public static T Instant => _instant;
        
       
        void Awake()
        {
            if (_instant != null && _instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                Debug.LogError("Singleton already exist "+ _instant.gameObject.name);
                Destroy(this.gameObject);
            }
            else
                _instant = this.GetComponent<T>();
                DontDestroyOnLoad(gameObject);
        }



    }
