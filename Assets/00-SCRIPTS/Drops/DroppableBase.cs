using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableBase : MonoBehaviour,ICollectable
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] public bool collected;
    [SerializeField] float timer;
    private void OnEnable() {
        collected=false;
    }

    public void Collect(Player player)

    {
        if (collected) return;

        collected = true;
        StartCoroutine(MoveToPlayer(player));
        // player.GetComponent<PlayerLevel>().UpdateCurrentXP();
    }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawWireSphere(transform.position, rangeCheck);
    // }
    IEnumerator MoveToPlayer(Player player)
    {

        timer = 0;
        Vector2 initPos = transform.position;
        while (timer < 1)
        {
            transform.position = Vector2.Lerp(initPos, player.transform.position, timer);
            timer += Time.deltaTime;

            yield return null;
        }
        Collected();

    }
    protected virtual void Collected(){
        gameObject.SetActive(false);
    }
}
