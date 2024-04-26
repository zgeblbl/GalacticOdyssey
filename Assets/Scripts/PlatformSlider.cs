using System.Collections;
using UnityEngine;

public class PlatformSlider : MonoBehaviour
{
    public float moveDistance = 10.0f;
    public float moveSpeed = 2.0f;

    private Vector3 initialPosition;
    private bool movingRight = true;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MovePlatform());
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
