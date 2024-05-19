using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScorePopUpController : MonoBehaviour
{  
   private Dictionary<string, int> scoreDictAmount = new()
   {
      {"Perfect", 0},
      {"Great", 0},
      {"Bad", 0},
      {"Miss", 0}
   };

   public void ResetScore() {
      foreach (var key in scoreDictAmount.Keys.ToList())
      {
         scoreDictAmount[key] = 0;
      }
   }

   public void UpdateScoreAmount (Vector3 position, string score)
   {
      foreach (var key in scoreDictAmount.Keys.ToList())
      {
         scoreDictAmount[key] = (score == key) ? scoreDictAmount[key] + 1 : 0;
      }

      ScorePopUpUI.Create(position, score, scoreDictAmount[score]);
   }

}
