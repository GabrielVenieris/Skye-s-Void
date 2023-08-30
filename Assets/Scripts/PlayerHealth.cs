using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Defini a quantidade de vida o player tem e o que acontece quando chega a 0
*/

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Healthbar healthBar;
    public GameManager GameManager;


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
            GameManager.BackToMenu();
            TimeCounter.sceneStarted = false;
        }
    }
}
