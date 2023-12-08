using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(quake(2.0f));
        }
    }

    private IEnumerator quake(float duration)
    {
        Vector3 original_pos = transform.localPosition;

        float elapsed = 0.0f;
        float currentMagnitude = 2.0f;

        while (elapsed < duration)
        {
            float x = (Random.value - 0.5f) * currentMagnitude;
            float y = (Random.value - 0.5f) * currentMagnitude;

            transform.localPosition = new Vector3(original_pos.x - x, original_pos.y - y, original_pos.z);

            elapsed += Time.deltaTime;
            currentMagnitude = (1 - (elapsed / duration)) * (1 - (elapsed / duration));

            yield return null;
        }

        transform.localPosition = original_pos;
    }
}
