using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    public float BallSpeed { get; set; } = 5f;
    public float TimeToReachTarget { get; set; } = 1f;

    protected Shooter shooter;
    private Player player;

    private void Awake()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter").GetComponent<Shooter>();  
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, BallSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetObject.transform.position);
        TimeToReachTarget = distance / BallSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shooter.Balls.Remove(this);
            player.Health -= 1;
            Destroy(gameObject);
        }
    }
}
