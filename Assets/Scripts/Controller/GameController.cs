using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class GameController : MonoBehaviour
{
   private GameObject settingPanel;

   private void Start() {
      settingPanel = GameObject.FindGameObjectWithTag("SettingPanel");
      settingPanel.SetActive(false);

      Time.timeScale = 1;
   }
}
