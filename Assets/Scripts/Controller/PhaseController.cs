using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class PhaseController : MonoBehaviour
{
   private int phase = 1;

   private readonly List<float> spawnRates = new() { 2f, 1f, 0.7f, 0.5f, 0.3f, 0.25f, 0.2f, 0.2f, 0.15f, 0.14f };
   private readonly List<float> ballSpeeds = new() { 1.5f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f };
   private readonly List<int> numberOfBalls = new() { 10, 15, 20, 25, 30, 35, 40, 45, 50 };
   public int CurrentNumberOfBalls {get; set;} = 0;

   private void Start() {
      Debug.Log("Phase: " + phase);
   }

   private void Update() {
      NextPhase();
   }

   public float GetCurrentSpawnRate() {
      return phase > spawnRates.Count ? spawnRates[^1] : spawnRates[phase - 1];
   }

   public float GetCurrentBallSpeed() {
      return phase > ballSpeeds.Count ? ballSpeeds[^1] : ballSpeeds[phase - 1];
   }

   public void NextPhase() {
      if (CurrentNumberOfBalls >= numberOfBalls[phase]) {
         phase++;
         CurrentNumberOfBalls = 0;
         Debug.Log("Phase: " + phase);
      }  
   }

}
