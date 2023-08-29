using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanning : MonoBehaviour
{
    public AppData appData;
    public float panSpeed = 0.1f;  // Adjust the speed of panning
    private Vector3 touchStart;
    private bool isDragging = false;

    void Update()
    {
        // Checks if the menu is open
        if (!appData.GetOpenMenu())
        {
            // Check for touch input
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                // Check for touch phase
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Store the starting touch position
                        touchStart = new Vector3(touch.position.x, 0f, touch.position.y);
                        isDragging = true;
                        break;
                    case TouchPhase.Moved:
                        if (isDragging)
                        {
                            // Calculate the panning distance based on touch delta
                            Vector3 touchDelta = new Vector3(touch.position.x, 0f, touch.position.y) - touchStart;
                            Vector3 pan = -touchDelta * panSpeed * Time.deltaTime;

                            // Apply the panning to the camera's position
                            transform.Translate(pan, Space.World);

                            // Update the touch start position for smooth panning
                            touchStart = new Vector3(touch.position.x, 0f, touch.position.y);
                        }
                        break;
                    case TouchPhase.Ended:
                        isDragging = false;
                        break;
                }
            }
        }
    }
}
