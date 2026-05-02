using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

public class LerpMovementLocal : MonoBehaviour
{
    [SerializeField] private Transform target;   // object to move
    [SerializeField] private Vector3 startPos;   // starting local position
    [SerializeField] private Vector3 endPos;     // ending local position
    [SerializeField] private float duration = 2f; // time in seconds

    private void Start()
    {
        if (target == null) target = transform; // default to self
        StartCoroutine(LerpLocalPosition(startPos, endPos, duration));
    }

    private IEnumerator LerpLocalPosition(Vector3 start, Vector3 end, float time)
    {
        float elapsed = 0f;

        while (elapsed < time)
        {
            float t = elapsed / time;
            target.localPosition = Vector3.Lerp(start, end, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.localPosition = end; // snap to final local position
    }

    [Button]
    void CopyCurrentStartPosition()
    {
        startPos = target.localPosition;
    }

    [Button]
    void CopyCurrentEndPosition()
    {
        endPos = target.localPosition;
    }

    [Button]
    void SetStartPosition()
    {
        target.localPosition = startPos;
    }

    [Button]
    void SetEndPosition()
    {
        target.localPosition = endPos;
    }
}
