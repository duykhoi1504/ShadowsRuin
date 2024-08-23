using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    // Start is called before the first frame update

    [SerializeField] private VFXData[] VFXs;


    [System.Serializable]
    public class VFXData
    {
        public string name;
        public GameObject effect;
    }

    public GameObject SpawnVFX(string name, Vector2 _pos)
    {
         GameObject vfxPrefab;
        VFXData temp = null;
        foreach (VFXData a in VFXs)
        {
            if (a.name == name)
            {
                temp = a;
                break;
            }
        }
        if (temp != null)
        {
            vfxPrefab = temp.effect;
            GameObject fx = Instantiate(vfxPrefab, _pos, Quaternion.identity);
            fx.SetActive(true);

            return fx;
            // StartCoroutine(waitForEffect(6f));
        }
        else
        {
            Debug.Log("khong tim thay vfx");
            return null;
        }
        
    }



}
