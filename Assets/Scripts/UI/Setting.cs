using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingPanel;
    private bool isOn = false;

    public void OnClick() {
        isOn = !isOn;
        settingPanel.SetActive(isOn);
        Time.timeScale = isOn ? 0 : 1;
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnClick();
        }
    }
}
