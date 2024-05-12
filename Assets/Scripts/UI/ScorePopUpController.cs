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

   private Player player;

   private void Start() {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
   }

   public void UpdateScoreAmount (string score)
   {
      scoreDictAmount[score] += 1;
      foreach (var key in scoreDictAmount.Keys.ToList())
      {
         Debug.Log(key + " " + scoreDictAmount[key]);
         if (key != score) scoreDictAmount[key] = 0;
      }

      Debug.Log(scoreDictAmount);

      ScorePopUpUI.Create(player.transform.position, score, scoreDictAmount[score]);
   }

}
