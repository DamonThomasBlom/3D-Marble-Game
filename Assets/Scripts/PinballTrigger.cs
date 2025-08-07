using UnityEngine;

public class PinballTrigger : MonoBehaviour
{
    public enum SlotEffect
    {
        Release,
        TimesTwo,
    }

    public SlotEffect slotEffect = SlotEffect.Release;
    public PinballMinigame PinballMinigame;

    private Collider _collider;
    private MeshRenderer _renderer;
    private Color _startColour;

    private void Start()
    {
        PinballMinigame = GetComponentInParent<PinballMinigame>();

        _collider = GetComponent<Collider>();
        _renderer = GetComponent<MeshRenderer>();
        _startColour = _renderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PinBall"))
        {
            PinballMinigame.ResetBallPosition(other.gameObject);
            TriggerEffect();
        }
    }

    public void TriggerEffect()
    {
        // You can customize different slot behavior here
        switch (slotEffect)
        {
            case SlotEffect.TimesTwo:
                PinballMinigame.DoubleBallCount();
                break;

            case SlotEffect.Release:
                PinballMinigame.Release();
                SetEnabled(false);
                break;
        }
    }

    public void SetEnabled(bool enabled)
    {
        if (enabled)
        {
            _collider.isTrigger = true;
            _renderer.material.color = _startColour;
        }
        else
        {
            _collider.isTrigger = false;
            _renderer.material.color = Color.gray;
        }
    }
}
