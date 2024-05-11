using UnityEngine;

public class DownBallDetecter : Detecter
{
   protected override void BallPop()
   {
      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
         PressUpdateScore();
      }
   }

   private void Update()
   {
      BallPop();
   }
}