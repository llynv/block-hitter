using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{

    [SerializeField] private List<GameObject> shooterPosition;
    [SerializeField] private List<GameObject> ballPrefabs;
    private PhaseController phaseController;

    void Start()
    {
        phaseController = GameObject.FindGameObjectWithTag("Phase Controller").GetComponent<PhaseController>();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            int randomShooter = Random.Range(0, shooterPosition.Count);
            float ballSpeed = phaseController.GetCurrentBallSpeed();

            int randomBall = Random.Range(0, ballPrefabs.Count);

            GameObject ball = Instantiate(ballPrefabs[randomBall], shooterPosition[randomShooter].transform.position, Quaternion.identity) as GameObject;
            ball.GetComponent<Ball>().BallSpeed = ballSpeed;    
            if (shooterPosition[randomShooter].transform.name == "Right") {
                ball.transform.rotation = Quaternion.Euler(180, 0, 180);
            }

            phaseController.CurrentNumberOfBalls++;

            float spawnRate = phaseController.GetCurrentSpawnRate();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
