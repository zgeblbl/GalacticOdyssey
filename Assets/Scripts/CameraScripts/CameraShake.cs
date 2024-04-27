using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            
            float x = Random.Range(transform.localPosition.x-0.1f, transform.localPosition.x+0.1f) * magnitude;
            float y = Random.Range(transform.localPosition.y-0.1f, transform.localPosition.y+0.1f) * magnitude;

            transform.localPosition = new Vector3(x , y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        elapsed = 0.0f;
        while (elapsed < smoothTime)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, transform.localPosition = Camera.main.GetComponent<CameraFollow>().target.position, ref velocity, smoothTime);
            elapsed += Time.deltaTime;
        };
        transform.localPosition = new Vector3(transform.localPosition.x, 0, -1);
        
    }
}
