using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float parallaxEffect = 0.5f; // Parallax effect ratio

    private Vector3 startPos; // Initial position of the background

    private void Start()
    {
        // Store the initial position
        startPos = transform.position;
    }

    private void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePos.z = 0;
        // Calculate the distance the background should move based on the mouse position
        float distanceX = mousePos.x  * parallaxEffect;
        float distanceY = mousePos.y * parallaxEffect;

        // Update the position of the background
        transform.position =mousePos;
        transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, 0);
    }
}