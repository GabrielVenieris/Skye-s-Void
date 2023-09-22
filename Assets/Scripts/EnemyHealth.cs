using UnityEngine;

/*
Define a vida do inimigo e o que acontece quando ele fica com 0 de vida;
Define o que acontece quando o boss morre;
*/

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 1;
    public bool isBoss = false; 
    

    
    private EnemyGenerator enemyGenerator; // Referência ao EnemyGenerator
    private LevelManager levelManager;



    private void Start()
    {
        health = maxHealth; // Define a vida inicial
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
        levelManager = FindAnyObjectByType<LevelManager>();
        
        // Defina a vida inicial com base em se este é um boss ou não
        if (isBoss)
        {
            health = levelManager.bossHealth; // Use a vida específica para chefes
        }
        else
        {
            maxHealth = levelManager.enemyHealth; // Use a vida padrão
        }
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
        if (!isBoss)
        {
            enemyGenerator.AddDeadEnemy(this); // Adicione este inimigo morto ao EnemyGenerator (não para o boss)
        }
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