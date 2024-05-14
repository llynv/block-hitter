using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBall : Ball
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag.CompareTo("Player") == 0)
      {
         shooter.CurrentNumberOfBalls--;
         Destroy(gameObject);
      }
   }
}
