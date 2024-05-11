using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RightBallDetecter : Detecter
{
   protected override void BallPop()
   {
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
         PressActionUpdate();
      }
   }

   private void Update()
   {
      BallPop();
   }
}