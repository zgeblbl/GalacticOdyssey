using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSpaceship : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    public Transform target;
    private float minHeightToFollow = 5f; // Minimum height for camera to start following
    private float playerOffset = 2f; // Offset from the player's position

    private void Update()
    {
        // Check if the player's y-position is greater than the minimum height to start following
        if (target.position.y >= minHeightToFollow)
        {
            // Smoothly move the camera to the target position
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        // Offset player horizontally based on movement direction
        if (Input.GetKey(KeyCode.A)) // Player is to the right of the camera
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x - playerOffset, transform.position.y, transform.position.z), ref velocity, smoothTime);
        }
        else if (Input.GetKey(KeyCode.D)) // Player is to the left of the camera
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x + playerOffset, transform.position.y, transform.position.z), ref velocity, smoothTime);

        }
    }
}
