using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PhaseController : MonoBehaviour
{
   public int CurrentNumberOfBalls { get; set; } = 0;
   public int Phase { get; private set; } = 1;

   Vector3 centrePosition, initPosition;
   private readonly List<float> spawnRates = new() { 2f, 1f, 0.7f, 0.5f, 0.3f, 0.25f, 0.2f, 0.2f, 0.15f, 0.14f };
   private readonly List<float> ballSpeeds = new() { 1.5f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f };
   private readonly List<int> numberOfBalls = new() { 10, 15, 20, 25, 30, 35, 40, 45, 50 };
   private PhaseUI phaseUI;
   private RectTransform canvasRectTransform;
   private Shooter shooter;
   private Player player;
   private Timer timer;
   private ScorePopUpController scorePopUpController;
   float speedRate = 500f;
   public enum PhaseType
   {
      UI,
      InPhase,
      Waiting
   }

   public PhaseType phaseType { get; private set; } = PhaseType.UI;

   private void Start()
   {
      phaseUI = GameObject.FindGameObjectWithTag("PhaseUI").GetComponent<PhaseUI>();
      canvasRectTransform = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>();
      shooter = GameObject.FindGameObjectWithTag("Shooter").GetComponent<Shooter>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
      scorePopUpController = GameObject.FindGameObjectWithTag("ScorePopUp").GetComponent<ScorePopUpController>();

      initPosition = new Vector3(Screen.width / 2, Screen.height, 0);
      centrePosition = new Vector3(Screen.width / 2, 3f * Screen.height / 5f, 0);
   }

   private bool isFirstEntry = false;
   private float waitingTime = 2f;
   private float changePhaseTime = 1f;

   private void Update()
   {
      initPosition = new Vector3(Screen.width / 2, Screen.height, 0);

      if (phaseType == PhaseType.Waiting) return;

      if (phaseType == PhaseType.UI)
      {
         if (shooter.CurrentNumberOfBalls > 0) return;

         changePhaseTime -= Time.deltaTime;

         if (changePhaseTime > 0 && Phase != 1) return;

         Camera.main.GetComponent<PostProcessVolume>().enabled = true;

         phaseUI.GetComponent<TextMeshProUGUI>().color = new Color32(210, 20, 20, 255);

         player.isDisabling = true;
         timer.isTimerActive = false;

         if (!isFirstEntry)
         {
            phaseUI.GetComponent<TextMeshProUGUI>().text = "Phase: " + Phase;
            phaseUI.transform.position = centrePosition;
            isFirstEntry = true;
            waitingTime = 2f;
            phaseUI.GetComponent<TextMeshProUGUI>().fontSize = 85;
         }

         if (waitingTime > 0)
         {
            waitingTime -= Time.deltaTime;
            return;
         }

         if (phaseUI.transform.position != initPosition)
         {
            phaseUI.transform.position = Vector3.MoveTowards(phaseUI.transform.position, initPosition, speedRate * Time.deltaTime);
            phaseUI.GetComponent<TextMeshProUGUI>().fontSize = Mathf.Lerp(phaseUI.GetComponent<TextMeshProUGUI>().fontSize, 36, Time.deltaTime);
            return;
         }

         phaseType = PhaseType.InPhase;

         Camera.main.GetComponent<PostProcessVolume>().enabled = false;

         phaseUI.GetComponent<TextMeshProUGUI>().color = new Color32(255, 25, 0, 255);
         phaseUI.GetComponent<TextMeshProUGUI>().fontSize = 36;

         isFirstEntry = false;
         player.isDisabling = false;
         timer.isTimerActive = true;
         shooter.StartAllCoroutine();

         changePhaseTime = 1f;
      }
      else
      {
         NextPhase();
      }
   }

   public float GetCurrentSpawnRate()
   {
      return Phase > spawnRates.Count ? spawnRates[^1] : spawnRates[Phase - 1];
   }

   public float GetCurrentBallSpeed()
   {
      return Phase > ballSpeeds.Count ? ballSpeeds[^1] : ballSpeeds[Phase - 1];
   }

   public int GetCurrentNumberOfBalls()
   {
      return Phase > numberOfBalls.Count ? numberOfBalls[^1] : numberOfBalls[Phase - 1];
   }

   public void NextPhase()
   {
      if (CurrentNumberOfBalls >= GetCurrentNumberOfBalls())
      {
         Phase++;
         CurrentNumberOfBalls = 0;
         phaseType = PhaseType.UI;
         scorePopUpController.ResetScore();
         shooter.StopAllCoroutines();
      }
   }

}
