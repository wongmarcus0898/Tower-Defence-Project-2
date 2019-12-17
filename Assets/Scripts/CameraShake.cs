using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector2 originalPos = transform.position;

        float timer = 0f;

        while (timer <= duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector2(x, y);

            timer += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
