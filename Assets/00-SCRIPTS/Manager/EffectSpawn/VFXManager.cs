using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    // Start is called before the first frame update

    [SerializeField] private VFX[] VFXs;
    [SerializeField] GameObject vfxPrefab;



    public void SpawnVFX(string name, Vector2 _pos)
    {
        VFX temp = null;
        foreach (VFX a in VFXs)
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


            // StartCoroutine(waitForEffect(6f));
        }
        else
        {
            Debug.Log("khong tim thay vfx");
        }
    }


    [System.Serializable]
    public class VFX
    {
        public string name;
        public GameObject effect;
    }
}
