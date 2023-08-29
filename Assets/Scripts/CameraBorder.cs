using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    public float minX = -10f; // Minimum X position
    public float maxX = 10f; // Maximum X position
    public float minZ = -10f; // Minimum Z position
    public float maxZ = 10f; // Maximum Z position

    private void LateUpdate()
    {
        // Get the camera's current position
        Vector3 cameraPosition = transform.position;

        // Clamp the camera's X and Z positions within the specified range
        float clampedX = Mathf.Clamp(cameraPosition.x, minX, maxX);
        float clampedZ = Mathf.Clamp(cameraPosition.z, minZ, maxZ);

        // Set the clamped position for the camera
        //transform.position = new Vector3(clampedX, cameraPosition.y, clampedZ);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("1");
        }
    }
}
