using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Make it static so we can call it from anywhere (Player or Projectile)
    public static CameraShake instance;

    // Save the original position of the camera so we can snap back to it
    private Vector3 originalPos;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalPos = transform.position;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    // Immediately stop any active shake and reset camera position
    public void StopShake()
    {
        StopAllCoroutines();
        transform.position = originalPos;
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Pick a random point inside a small circle
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Apply that offset to the camera
            transform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            // Wait for next frame
            yield return null;
        }

        // Snap back to center when done
        transform.position = originalPos;
    }
}