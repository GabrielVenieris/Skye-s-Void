using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Healthbar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

   public void TakeDamage (int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
        if(health <= 0)
        {
            SceneManager.LoadScene(0);
            TimeCounter.sceneStarted = false;
        }
    }
}
