
using UnityEngine;

// This script handles the main in-game camera following the player's motion

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;

    public Vector3 offset;

    void LateUpdate()
    {
        // Ensure that the player object is currently spawned into the scene
        if (target != null)
        {
            // Get the desired position of the camera and smooth the transition to this location
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPos;
            transform.LookAt(target);
        }
    }
}
