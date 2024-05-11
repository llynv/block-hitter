using UnityEngine;

public class LeftBallDetecter : Detecter
{
   protected override void BallPop()
   {
      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
         PressActionUpdate();
      }
   }

   private void Update()
   {
      BallPop();
   }
}