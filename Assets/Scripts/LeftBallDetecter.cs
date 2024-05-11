using UnityEngine;

public class LeftBallDetecter : Detecter
{
   protected override void BallPop ()
   {
      if (Input.GetKeyDown(KeyCode.LeftArrow)) {
         PressUpdateScore();
      }
   }

   private void Update() {
      BallPop();
   }
}