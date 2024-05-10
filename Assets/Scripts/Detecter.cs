using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public abstract class Detecter : MonoBehaviour
{
   public bool IsCollapsing { get; set; } = false;
   public float ballRadius = 0.5f;

   private Dictionary<string, int> scoreDict = new Dictionary<string, int> {
      {"Perfect", 100},
      {"Great", 50},
      {"Bad", 20},
      {"Miss", 0},
      {"Poison", -50}
   };
   private Player player;
   private Vector3 hitPosition = new Vector2();
   private ScoreUI scoreUI;
   private GameObject ball;
   private Shooter shooter;
   private bool isPoisonBall = false;

   private void Start()
   {
      scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUI>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      shooter = GameObject.FindGameObjectWithTag("Shooter").GetComponent<Shooter>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Ball")
      {
         ball = other.gameObject;
         isPoisonBall = ball.GetComponent<PoisonBall>() != null;
         hitPosition = other.transform.position;
         IsCollapsing = true;
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.tag == "Ball")
      {
         hitPosition = other.transform.position;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.tag == "Ball")
      {
         IsCollapsing = false;
      }
   }

   protected float CalculateDistance()
   {
      Debug.Log("Distance: " + Vector3.Distance(transform.position, hitPosition));
      return Vector3.Distance(transform.position, hitPosition);
   }


   protected void UpdateScore(string score)
   {
      player.Score += scoreDict[score];
   }

   protected void CalculateScore()
   {
      if (!IsCollapsing)
      {
         Debug.Log("Miss");
         UpdateScore("Miss");
         return;
      }

      shooter.RemoveBall(ball.GetComponent<Ball>());
      Destroy(ball);

      if (isPoisonBall)
      {
         UpdateScore("Poison");
         return;
      }

      float scaleDistance = CalculateDistance();
      switch (scaleDistance)
      {
         case float n when (n <= 0.1f):
            Debug.Log("Perfect");
            UpdateScore("Perfect");
            break;
         case float n when (n <= 0.3f):
            Debug.Log("Great");
            UpdateScore("Great");
            break;
         default:
            Debug.Log("Bad");
            UpdateScore("Bad");
            break;
      }
   }

   protected abstract void BallPop();
}
