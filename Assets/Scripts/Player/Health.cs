using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int MaxHealth = 3;
    public Image[] hearts;

    public int CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update() {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < CurrentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
