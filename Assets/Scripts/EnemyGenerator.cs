using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Define quantidade de inimigos na cena. Cria uma lista de inimigos e quando chega a zero(morrem todos) o jogo reinicia
*/

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform playerTransform;
    public float xPadding;
    private List<GameObject> enemies = new List<GameObject>();
    
    // Intervalo inicial entre spawns
    public float initialSpawnInterval = 10.0f; 
   
    // Decréscimo do intervalo a cada spawn
    public float spawnIntervalDecrement = 0.5f; 
    private float currentSpawnInterval;

    // Temporizador para controlar o próximo spawn
    private float timer = 0.0f; 

    // Contador de inimigos spawnado
    private int enemiesSpawned = 0; 





    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        SpawnEnemies(3);

        // float xDist = 0;
        // for(int i = 0; i <= 3; i++)
        // {
        //     GameObject enemy = Instantiate(enemyPrefab);
        //     enemy.GetComponent<EnemyChase>().player = playerTransform;
        //     enemy.transform.position = new Vector3(enemy.transform.position.x + xDist, enemy.transform.position.y, enemy.transform.position.z);
        //     xDist += xPadding;

        //     enemies.Add(enemy); // Add the instantiated enemy to the list
        // }
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            int enemiesToSpawn = Mathf.FloorToInt(enemiesSpawned * 0.5f) + 1;
            SpawnEnemies(enemiesToSpawn);

            // Ajuste o temporizador e a taxa de spawn
            timer = 0.0f;
            currentSpawnInterval -= spawnIntervalDecrement;
            // Defina um limite mínimo
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, 1.0f); 

            enemiesSpawned += enemiesToSpawn;
        }


        //IMPORTANTE PARA SABER SE JÁ PODE IR PRA PRÓXIMA ILHA
        // // Check if all enemies are destroyed
        // if (AreAllEnemiesDestroyed())
        // {
        //     SceneManager.LoadScene(0); // Load scene when all enemies are destroyed
        // }
    }

    private void SpawnEnemies(int count)
    {
        float xDist = 0;
        for (int i = 0; i < count; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyChase>().player = playerTransform;
            enemy.transform.position = new Vector3(enemy.transform.position.x + xDist, enemy.transform.position.y, enemy.transform.position.z);
            xDist += xPadding;

            enemies.Add(enemy);//Popula a lista de quantidade de inimigos
        }
    }






    //IMPORTANTE PARA SABER SE JÁ PODE IR PRA PRÓXIMA ILHA
    // bool AreAllEnemiesDestroyed()
    // {
    //     foreach (GameObject enemy in enemies)
    //     {
    //         if (enemy != null) // If any enemy still exists, return false
    //         {
    //             return false;
    //         }
    //     }
    //     return true; // All enemies are destroyed
    // }
}
