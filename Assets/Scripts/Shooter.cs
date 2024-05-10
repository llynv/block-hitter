using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    public List<Ball> Balls {get; set;} = new List<Ball>();

    [SerializeField] private List<GameObject> shooterPosition;
    [SerializeField] private List<GameObject> ballPrefabs;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(Shoot());
    }

    public void RemoveBall(Ball ball)
    {
        Balls.Remove(ball);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            int randomShooter = Random.Range(0, shooterPosition.Count);
            float randomBallSpeed = Random.Range(4f, 6f);
            float distance = Vector3.Distance(shooterPosition[randomShooter].transform.position, player.transform.position);
            float timeToReachTarget = distance / randomBallSpeed; 
            bool isBallCollapsing = true;

            int loopLimitExceeded = 50;
            while (isBallCollapsing && loopLimitExceeded --> 0)
            {
                // Debug.Log("Collapsing " + count++);
                randomBallSpeed = Random.Range(4f, 6f);
                distance = Vector3.Distance(shooterPosition[randomShooter].transform.position, player.transform.position);
                timeToReachTarget = distance / randomBallSpeed;
                isBallCollapsing = false;

                // Debug.Log("Distance: " + distance);
                // Debug.Log("Random ball speed: " + randomBallSpeed);
                Debug.Log("Time to reach target: " + timeToReachTarget);

                foreach (Ball currentBall in Balls)
                {
                    // Debug.Log("Current ball time to reach target: " + currentBall.TimeToReachTarget);
                    if (currentBall.TimeToReachTarget - timeToReachTarget <= .35f)
                    {
                        isBallCollapsing = true;
                        break;
                    }
                }
            }

            Debug.Log("Loop limit: " + loopLimitExceeded);

            if (loopLimitExceeded <= 0)
            {
                Debug.Log("Loop limit exceeded");
                yield return new WaitForSeconds(.15f);
            }

            int randomBall = Random.Range(0, ballPrefabs.Count);

            GameObject ball = Instantiate(ballPrefabs[randomBall], shooterPosition[randomShooter].transform.position, Quaternion.identity) as GameObject;
            ball.GetComponent<Ball>().BallSpeed = randomBallSpeed;
            Balls.Add(ball.GetComponent<Ball>());

            Debug.Log("Total Balls: " + Balls.Count);
            float randomTime = Random.Range(.4f, .6f);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
