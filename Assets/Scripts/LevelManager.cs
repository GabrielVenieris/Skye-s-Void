using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameLevel currentLevel;
    public int kills = 0;





    public int enemiesPerLevel = 30;
    public int enemyHealth = 1;
    public int enemyDamage = 1;

    public bool lastEnemyIsABoss = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevelCompleted();
    }


    public void SetupLevelChanged()
    {
        switch (currentLevel)
        {
            case GameLevel.Level1:
            SetupLevel(2);
                break; // Define a quantidade de inimigos para o Level 1

            case GameLevel.Level2:
            SetupLevel(3);
                break; // Define a quantidade de inimigos para o Level 2

            case GameLevel.Level3:
            SetupLevel(4);
                break; // Define a quantidade de inimigos para o Level 3

            // Adicione outros casos para outros níveis
            default:
                break; // Se o nível não for reconhecido, retorne 0 inimigos
        }
    }


     void CheckLevelCompleted()
{
    EnemyGenerator enemyGenerator = FindObjectOfType<EnemyGenerator>();
    if (enemyGenerator != null)
    {
        List<EnemyHealth> playerKillsList = enemyGenerator.GetEnemiesKilledList();
        // // Obtenha a quantidade de inimigos para o nível atual
        // int enemiesToSpawn = enemiesPerLevel; 
 
        // Verifique se a quantidade de inimigos mortos é igual à quantidade de inimigos a serem spawnados
        if (playerKillsList.Count == enemiesPerLevel)
        {
            SetupLevelChanged();
            GameManager.Instance.LoadNextLevel();
            return; // Nível completo
        }
    }

    return; // Nível não completo
}


void SetupLevel(int level) {
        kills = 0;
        // enemiesPerLevel = 1 * (1+ ((level-1)/10));
        enemyHealth     = 1 * (1 + ((level-1)/10));
        enemyDamage     = 1 * (1+ ((level-1)/10));
        lastEnemyIsABoss = (level == 3);
}


}



public enum GameLevel
{
    Level1,
    Level2,
    Level3,
}