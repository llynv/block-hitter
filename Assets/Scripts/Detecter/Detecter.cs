using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public abstract class Detecter : MonoBehaviour
{
   public bool IsCollapsing { get; set; } = false;
   public float ballRadius = 0.5f;

   private Dictionary<string, int> scoreDict = new()
   {
      {"Perfect", 100},
      {"Great", 50},
      {"Bad", 20},
      {"Miss", 0}
   };
   private ScorePopUpController scorePopUpController;
   private Player player;
   private Vector3 hitPosition = new Vector2();
   private ScoreUI scoreUI;
   private GameObject ball;
   private Shooter shooter;
   private bool isPoisonBall = false;

   private void Awake()
   {
      scorePopUpController = GameObject.FindGameObjectWithTag("ScorePopUp").GetComponent<ScorePopUpController>();
      scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUI>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      shooter = GameObject.FindGameObjectWithTag("Shooter").GetComponent<Shooter>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag.CompareTo("Ball") == 0)
      {
         ball = other.gameObject;
         isPoisonBall = ball.GetComponent<PoisonBall>() != null;
         hitPosition = other.transform.position;
         IsCollapsing = true;
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.tag.CompareTo("Ball") == 0)
      {
         hitPosition = other.transform.position;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.tag.CompareTo("Ball") == 0)
      {
         IsCollapsing = false;
      }
   }

   protected void PressActionUpdate()
   {
      StartCoroutine(CalculateScore());
   }


   protected void UpdateScore(string score)
   {
      player.Score += scoreDict[score];
      scorePopUpController.UpdateScoreAmount(score);
   }

   protected void UpdateHealth()
   {
      player.Health -= 1;
   }

   IEnumerator CalculateScore()
   {
      if (player.GetComponent<SpriteRenderer>().color == Color.white)
      {
         if (!IsCollapsing)
         {
            Debug.Log("Miss");
            UpdateScore("Miss");

            player.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(1.5f);
            player.GetComponent<SpriteRenderer>().color = Color.white;
            yield break;
         }

         shooter.Balls.Remove(ball.GetComponent<Ball>());
         Destroy(ball);


         if (isPoisonBall)
         {
            UpdateHealth();
         }

         float scaleDistance = Vector3.Distance(transform.position, hitPosition);
         switch (scaleDistance)
         {
            case float n when (n <= 0.1f):
               UpdateScore("Perfect");
               break;
            case float n when (n <= 0.3f):
               UpdateScore("Great");
               break;
            default:
               UpdateScore("Bad");
               break;
         }
      }
   }

   protected abstract void BallPop();
}
