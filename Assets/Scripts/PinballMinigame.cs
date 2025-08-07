using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinballMinigame : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI NumberOfBallsText;
    public Canon Canon;

    [Header("Ball Settings")]
    public GameObject ballPrefab;
    public Transform spawnAreaTopLeft;
    public Transform spawnAreaTopRight;

    [Header("Drop Settings")]
    public float respawnDelay = 0.5f;

    [Header("Slot Triggers")]
    public List<PinballTrigger> Triggers; // Assign these manually or find them via tag

    [HideInInspector]
    public int BallCount = 1;

    void Start()
    {
        AddBall();
    }

    [Button]
    public void AddBall()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnAreaTopLeft.position.x, spawnAreaTopRight.position.x),
            spawnAreaTopLeft.position.y,
            spawnAreaTopLeft.position.z
        );

        var currentBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
    }

    public void ResetBallPosition(GameObject ball)
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnAreaTopLeft.position.x, spawnAreaTopRight.position.x),
            spawnAreaTopLeft.position.y,
            spawnAreaTopLeft.position.z
        );

        ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ball.transform.position = spawnPos;
    }

    public void Release()
    {
        Canon.ShootBall(BallCount);
        SetBallCount(1);
    }

    public void DoubleBallCount()
    {
        SetBallCount(BallCount * 2);
    }

    public void TripleBallCount()
    {
        SetBallCount(BallCount * 3);
    }

    public void SetBallCount(int count)
    {
        BallCount = count;
        if (NumberOfBallsText)
            NumberOfBallsText.text = count.ToString();

        // Re-enable the triggers
        if (count == 1)
            foreach(var trigger in Triggers) { trigger.SetEnabled(true); }
        //if (BallCount > 1000)
        //    Release();
    }

    public void Die()
    {
        foreach (var slot in Triggers) { slot.SetEnabled(false); }
    }
}
