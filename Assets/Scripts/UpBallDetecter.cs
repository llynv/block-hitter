using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpBallDetecter : Detecter
{
   protected override void BallPop()
   {
      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
         PressUpdateScore();
      }
   }

   private void Update()
   {
      BallPop();
   }
}