using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameLevel currentLevel;



    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int GetEnemiesForCurrentLevel()
    {
        switch (currentLevel)
        {
            case GameLevel.Level1:
                // LevelCompleted();
                return 10; // Define a quantidade de inimigos para o Level 1
            case GameLevel.Level2:
                return 35; // Define a quantidade de inimigos para o Level 2
            case GameLevel.Level3:
                return 50; // Define a quantidade de inimigos para o Level 3
            // Adicione outros casos para outros níveis
            default:
                return 0; // Se o nível não for reconhecido, retorne 0 inimigos
        }
    }


     bool LevelCompleted()
{
    EnemyGenerator enemyGenerator = FindObjectOfType<EnemyGenerator>();
    if (enemyGenerator != null)
    {
        List<EnemyHealth> enemiesList = enemyGenerator.GetEnemiesKilledList();
        int enemiesToSpawn = GetEnemiesForCurrentLevel(); // Obtenha a quantidade de inimigos para o nível atual
 
        // Verifique se a quantidade de inimigos mortos é igual à quantidade de inimigos a serem spawnados
        if (enemiesList.Count == enemiesToSpawn)
        {
            GameManager.Instance.LoadNextLevel();
            return true; // Nível completo
        }
    }

    return false; // Nível não completo
}




}



public enum GameLevel
{
    Level1,
    Level2,
    Level3,
}
