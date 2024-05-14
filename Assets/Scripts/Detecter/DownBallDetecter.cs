using UnityEngine;

public class DownBallDetecter : Detecter
{
   protected override void BallPop()
   {
      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
         PressActionUpdate(transform.position);
      }
   }

   private void Update()
   {
      BallPop();
   }
}