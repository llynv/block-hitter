using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void SwitchScene() {
        SceneManager.LoadScene("SampleScene");    
    }

    public void ExitGame() {
        Application.Quit();
    }
}
