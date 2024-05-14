using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhaseUI : MonoBehaviour
{
   private PhaseController phaseController;

   private void Start()
   {
      phaseController = GameObject.FindGameObjectWithTag("Phase Controller").GetComponent<PhaseController>();
   }

   void Update()
   {
      // transform.GetComponent<TextMeshProUGUI>().text = "Phase " + phaseController.Phase.ToString();
   }
}
