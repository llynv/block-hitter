using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    public List<Ball> Balls { get; set; } = new List<Ball>();

    [SerializeField] private List<GameObject> shooterPosition;
    [SerializeField] private List<GameObject> ballPrefabs;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            int randomShooter = Random.Range(0, shooterPosition.Count);
            float randomBallSpeed = Random.Range(4.5f, 6.5f);
            float distance = Vector3.Distance(shooterPosition[randomShooter].transform.position, player.transform.position);
            float timeToReachTarget = distance / randomBallSpeed;
            bool isBallCollapsing = true;

            int loopLimitExceeded = 50;
            while (isBallCollapsing && loopLimitExceeded-- > 0)
            {
                randomBallSpeed = Random.Range(4.5f, 6.5f);
                distance = Vector3.Distance(shooterPosition[randomShooter].transform.position, player.transform.position);
                timeToReachTarget = distance / randomBallSpeed;
                isBallCollapsing = false;

                foreach (Ball currentBall in Balls)
                {
                    if (currentBall.TimeToReachTarget - timeToReachTarget <= .35f)
                    {
                        isBallCollapsing = true;
                        break;
                    }
                }
            }

            if (loopLimitExceeded <= 0)
            {
                yield return new WaitForSeconds(.15f);
            }

            int randomBall = Random.Range(0, ballPrefabs.Count);

            GameObject ball = Instantiate(ballPrefabs[randomBall], shooterPosition[randomShooter].transform.position, Quaternion.identity) as GameObject;
            ball.GetComponent<Ball>().BallSpeed = randomBallSpeed;
            Balls.Add(ball.GetComponent<Ball>());

            float randomTime = Random.Range(.35f, .6f);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
