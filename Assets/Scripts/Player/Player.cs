using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public int Health { get; set; } = 3;
    public bool isDisabling = false;

    private Health health;

    private void Awake() {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        health.CurrentHealth = Health;
        if (Health <= 0)
        {
            Debug.Log("Game Over");
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
