using UnityEngine;

public class LeftBallDetecter : Detecter
{
   protected override void BallPop ()
   {
      if (Input.GetKeyDown(KeyCode.LeftArrow)) {
         CalculateScore();
      }
   }

   private void Update() {
      BallPop();
   }
}