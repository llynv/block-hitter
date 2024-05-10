using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpBallDetecter : Detecter
{
   protected override void BallPop ()
   {
      if (Input.GetKeyDown(KeyCode.UpArrow)) {
         CalculateScore();
      }
   }

   private void Update() {
      BallPop();
   }
}