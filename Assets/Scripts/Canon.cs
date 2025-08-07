using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Canon : MonoBehaviour
{
    public Transform BallSpawnPoint;
    public float ShootSpeed;
    public float ShootIterations = 0.2f;
    public ObjectPooler Pooler;
    public PinballMinigame PinballGame;

    [Header("Canon Sweep")]
    public float sweepAngle = 45f; // How far it turns left/right
    public float sweepSpeed = 1f;  // How fast it sweeps

    private float startRotation;

    void Start()
    {
        startRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        float angle = Mathf.PingPong(Time.time * sweepSpeed, sweepAngle * 2) - sweepAngle;
        transform.rotation = Quaternion.Euler(0f, startRotation + angle, 0f);
    }

    int ballcount = 0;

    [Button]
    public void ShootBall(int numberOfBalls)
    {
        ballcount = numberOfBalls;
        StartCoroutine(ShootBallsSlowly(numberOfBalls));
    }

    public float randomnessAngle = .1f;

    IEnumerator ShootBallsSlowly(int numberOfBalls)
    {
        int ballsLeftToShoot = numberOfBalls;

        for (int i = 0; i < numberOfBalls; i++)
        {
            var ball = Pooler.GetFromPool(BallSpawnPoint.position, Quaternion.identity);

            // Add slight randomness to the shoot direction
            Vector3 randomOffset = new Vector3(
                Random.Range(-randomnessAngle, randomnessAngle),
                Random.Range(-randomnessAngle, randomnessAngle),
                Random.Range(-randomnessAngle, randomnessAngle)
            );

            Vector3 shootDirection = (BallSpawnPoint.transform.forward + randomOffset).normalized;

            ball.GetComponent<Rigidbody>().AddForce(shootDirection * ShootSpeed, ForceMode.Impulse);

            ballcount--;
            PinballGame.SetBallCount(ballcount);

            yield return new WaitForSeconds(ShootIterations);
        }

        PinballGame.SetBallCount(1);
    }

    public void Die()
    {
        PinballGame.Die();
        gameObject.SetActive(false);
    }
}
