using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class LerpScale : MonoBehaviour
{
    [SerializeField] private Transform target;   // object to move
    [SerializeField] private Vector3 startScale;   // starting local position
    [SerializeField] private Vector3 endScale;     // ending local position
    [SerializeField] private float duration = 2f; // time in seconds

    private void Start()
    {
        if (target == null) target = transform; // default to self
        StartCoroutine(LerpLocalPosition(startScale, endScale, duration));
    }

    private IEnumerator LerpLocalPosition(Vector3 start, Vector3 end, float time)
    {
        float elapsed = 0f;

        while (elapsed < time)
        {
            float t = elapsed / time;
            target.localScale = Vector3.Lerp(start, end, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.localScale = end; // snap to final local position
    }

    [Button]
    void SetStartScale()
    {
        target.localScale = startScale;
    }

    [Button]
    void SetEndScale()
    {
        target.localScale = endScale;
    }
}
