using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Define a vida do inimigo e o que acontece quando ele fica com 0 de vida
*/

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    

    
    private EnemyGenerator enemyGenerator; // Referência ao EnemyGenerator



    private void Start()
    {
        health = maxHealth; // Define a vida inicial
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
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
        enemyGenerator.AddDeadEnemy(this); // Adicione este inimigo morto ao EnemyGenerator
        
        // Realiza ações de morte do inimigo, como tocar uma animação, gerar partículas, etc.
        Destroy(gameObject); // Destroi o objeto do inimigo
    }


//      public void KillCount()
// {
//     Debug.Log("KillCount function called");
//     int enemyKillCount = enemiesList.Count;
//     print("Kills: " + enemyKillCount);
// }


}
