using UnityEngine;

public class DestroyOnLeave : MonoBehaviour
{
    void Update()
    {
        if (!IsInView())
        {
            Destroy(gameObject);
        }
    }

    bool IsInView()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
