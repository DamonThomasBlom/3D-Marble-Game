using UnityEngine;
using UnityEngine.Events;

public class TriggerEventOnTag : MonoBehaviour
{
    [Tooltip("Tag to check when something enters the trigger")]
    public string TagToCheck = "TagToCheck";

    [Tooltip("Event to invoke when a valid object enters the trigger")]
    public UnityEvent OnTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagToCheck))
        {
            OnTriggerEnterEvent?.Invoke();
        }
    }
}
