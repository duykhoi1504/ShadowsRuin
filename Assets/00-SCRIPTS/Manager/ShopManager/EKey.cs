using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EKey : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject light;
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onExit;

    // [SerializeField] float floatAmplitude = 0.1f; // Amplitude of the floating effect
    // [SerializeField] float floatFrequency = 2f; // Frequency of the floating effect
    // private Vector3 startPosition;
    // [SerializeField] private bool isFloating = true;
  
    private void Start()
    {
        light.SetActive(false);
    }
    private void Update()
    {
        // if (isFloating)
        // {
        //     // Calculate the new position based on sine wave
        //     float newY = this.transform.position.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        //     transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            // ShopManager.Instant.canOpen = true;
            onEnter?.Invoke();
            light.SetActive(true);
            this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            // ShopManager.Instant.canOpen = false;
             onExit?.Invoke();

            light.SetActive(false);

            this.transform.localScale = Vector3.one;
        }
    }
    public void ShopManagerOpen(bool _canOpen){
             ShopManager.Instant.canOpen = _canOpen;
    }
     public void QuestManagerOpen(bool _canOpen){
             QuestManager.Instant.canOpen = _canOpen;
    }
}
