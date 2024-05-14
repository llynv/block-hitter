using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detecter : MonoBehaviour
{
   public bool IsCollapsing { get; set; } = false;
   public float ballRadius = 0.5f;

   private Dictionary<string, int> scoreDict = new()
   {
      {"Perfect", 100},
      {"Great", 50},
      {"Bad", 20}
   };
   private ScorePopUpController scorePopUpController;
   private Player player;
   private Vector3 hitPosition = new Vector2();
   private ScoreUI scoreUI;
   private GameObject ball;
   private Shooter shooter;
   private PhaseController phaseController;
   private bool isPoisonBall = false;

   private void Awake()
   {
      scorePopUpController = GameObject.FindGameObjectWithTag("ScorePopUp").GetComponent<ScorePopUpController>();
      scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUI>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      shooter = GameObject.FindGameObjectWithTag("Shooter").GetComponent<Shooter>();
      phaseController = GameObject.FindGameObjectWithTag("Phase Controller").GetComponent<PhaseController>();
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

   protected void PressActionUpdate(Vector3 position)
   {
      if (player.isDisabling) return;
      StartCoroutine(CalculateScore(position));
   }


   protected void UpdateScore(Vector3 position, string score)
   {
      player.Score += scoreDict[score];
      scorePopUpController.UpdateScoreAmount(position, score);
   }

   protected void UpdateHealth()
   {
      player.Health -= 1;
   }

   IEnumerator CalculateScore(Vector3 position)
   {
      if (player.GetComponent<SpriteRenderer>().color == Color.white)
      {
         if (!IsCollapsing)
         {
            player.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0, 0.6f);
            float freezeTime = 3f * phaseController.GetCurrentSpawnRate() / 4f;
            player.isDisabling = true;
            yield return new WaitForSeconds(freezeTime);
            player.GetComponent<SpriteRenderer>().color = Color.white;
            player.isDisabling = false;
            yield break;
         }

         shooter.CurrentNumberOfBalls--;
         Destroy(ball);

         if (isPoisonBall)
         {
            UpdateHealth();
            yield break;
         }

         float scaleDistance = Vector3.Distance(transform.position, hitPosition);
         switch (scaleDistance)
         {
            case float n when (n <= 0.1f):
               UpdateScore(position, "Perfect");
               break;
            case float n when (n <= 0.3f):
               UpdateScore(position, "Great");
               break;
            default:
               UpdateScore(position, "Bad");
               break;
         }
      }
   }

   protected abstract void BallPop();
}
