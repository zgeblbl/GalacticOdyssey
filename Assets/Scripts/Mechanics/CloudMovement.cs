using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    public float moveDistance = 10.0f;
    public float moveSpeed = 2.0f;

    private Vector3 initialPosition;
    private bool movingRight = true;
    public float speed = 2.0f;
    public float wobbleMagnitude = 0.5f;
    public float wobbleSpeed = 2.0f;
    public float boundaryX = 10.0f;

    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MovePlatform());
    }

    void Update()
    {
        // Move the cloud
        transform.Translate(Vector3.right * speed * Time.deltaTime * direction);

        // Check if the cloud reaches the boundary
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= boundaryX)
        {
            // Change direction
            direction *= -1;
        }

        // Calculate the vertical wobble effect
        float wobbleOffset = Mathf.Sin(Time.time * wobbleSpeed) * wobbleMagnitude;

        // Apply the wobble effect to the cloud's position
        transform.position = new Vector3(transform.position.x, initialPosition.y + wobbleOffset, transform.position.z);
    }
    IEnumerator MovePlatform()
    {
        while (true)
        {
            float targetX = movingRight ? initialPosition.x + moveDistance : initialPosition.x;
            Vector3 targetPosition = new Vector3(targetX, initialPosition.y, initialPosition.z);
            float distance = Vector3.Distance(transform.position, targetPosition);

            while (distance > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                distance = Vector3.Distance(transform.position, targetPosition);
                yield return null;
            }

            movingRight = !movingRight;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
