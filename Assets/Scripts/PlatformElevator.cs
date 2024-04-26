using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformElevator : MonoBehaviour
{

    public float moveDistance = 2.0f; // Total distance the platform will move
    public float moveSpeed = 2.0f; // Speed at which the platform moves

    private Vector3 initialPosition;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            float targetY = movingUp ? initialPosition.y + moveDistance : initialPosition.y;
            Vector3 targetPosition = new Vector3(initialPosition.x, targetY, initialPosition.z);
            float distance = Vector3.Distance(transform.position, targetPosition);

            while (distance > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                distance = Vector3.Distance(transform.position, targetPosition);
                yield return null;
            }

            movingUp = !movingUp;
            yield return new WaitForSeconds(1.0f); // Wait for 1 second at the destination before moving again
        }
    }
}
