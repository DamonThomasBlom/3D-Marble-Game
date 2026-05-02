using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    public float updateInterval = 0.5f;

    private float accumulated = 0f; // FPS accumulated over the interval
    private int frames = 0;         // Frames drawn over the interval
    private float timeLeft;         // Left time for current interval

    void Start()
    {
        if (fpsText == null)
            Debug.LogError("FPSCounter: Please assign a Text component.");
        timeLeft = updateInterval;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        accumulated += Time.timeScale / Time.deltaTime;
        ++frames;

        // Interval ended — update the text
        if (timeLeft <= 0.0)
        {
            float fps = accumulated / frames;
            fpsText.text = $"{fps:F0} FPS";

            timeLeft = updateInterval;
            accumulated = 0f;
            frames = 0;
        }
    }
}
