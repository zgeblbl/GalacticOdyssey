using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSpaceship : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    public Transform target;
    private float minHeightToFollow = 5f;
    private float playerOffset = 2f;
    private float leftSideLimit = 0f;

    private void Update()
    {
        
        if (target.position.y >= minHeightToFollow)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        if (target.position.x > leftSideLimit)
        {
            if (Input.GetKey(KeyCode.A)) 
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x - playerOffset, transform.position.y, transform.position.z), ref velocity, smoothTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x + playerOffset, transform.position.y, transform.position.z), ref velocity, smoothTime);

            }
        }
         
        
    }
}
