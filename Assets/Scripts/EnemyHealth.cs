using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     public int health;
    public int maxHealth = 10;

    private void Start()
    {
        health = maxHealth; // Define a vida inicial
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Reduz a vida pelo valor do dano

        if (health <= 0)
        {
            Die(); // Chama o método para destruir o inimigo
        }
    }

    private void Die()
    {
        // Realiza ações de morte do inimigo, como tocar uma animação, gerar partículas, etc.
        Destroy(gameObject); // Destroi o objeto do inimigo
    }
}
