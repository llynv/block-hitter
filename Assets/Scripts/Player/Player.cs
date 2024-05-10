using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public int Health { get; set; } = 3;

    private void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Game Over");
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
