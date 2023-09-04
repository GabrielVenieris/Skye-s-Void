using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

/*
Define quantidade de inimigos na cena. Cria uma lista de inimigos e quando chega a zero(morrem todos) o jogo reinicia
*/

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform playerTransform;
    public float xPadding;
    // Decréscimo do intervalo a cada spawn
    public float spawnIntervalDecrement = 0.5f;
     // Intervalo inicial entre spawns
    public float initialSpawnInterval = 10.0f;
    // Referência ao mapa
    public GameObject Tilemap; 

    
    
    private float currentSpawnInterval;
   // Temporizador para controlar o próximo spawn
    private float timer = 0.0f; 
    // Contador de inimigos spawnado
    private int enemiesSpawned = 0;
    // Renderer component of the map bounds object
    private Tilemap tilemap;
    private BoundsInt tilemapBounds;
    // Referência ao Level Manager
    private LevelManager levelManager; 
    // Lista de inimigos mortos
    private List<EnemyHealth> enemiesList = new List<EnemyHealth>(); 



    

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        tilemap = Tilemap.GetComponent<Tilemap>();
        tilemapBounds = tilemap.cellBounds;
        // SpawnEnemies(3);
        // Obtenha a referência para o Level Manager
        levelManager = FindObjectOfType<LevelManager>();

        // Verifique se o Level Manager foi encontrado
        if (levelManager == null)
        {
            Debug.LogError("Level Manager não encontrado.");
        }

        int enemiesToSpawn = levelManager.GetEnemiesForCurrentLevel(); // Obtenha a quantidade de inimigos para o nível atual
        SpawnEnemies(enemiesToSpawn);

    }

    void Update()
    {
        KillCount();

        timer += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            int enemiesToSpawn = Mathf.FloorToInt(enemiesSpawned * 0.5f) + 1;
            SpawnEnemies(enemiesToSpawn);

            // Ajuste o temporizador e a taxa de spawn
            timer = 0.0f;
            // currentSpawnInterval -= spawnIntervalDecrement;
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


    private void SpawnEnemies(int enemiesToSpawn)
{
    for (int i = 0; i < enemiesToSpawn; i++)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<EnemyChase>().player = playerTransform;
        // Get a random cell position within the tilemap bounds
        Vector3Int randomCell = new Vector3Int(
            Random.Range(tilemapBounds.xMin, tilemapBounds.xMax),
            Random.Range(tilemapBounds.yMin, tilemapBounds.yMax),
            0);
        // Convert cell position to world position
        Vector3 randomPosition = tilemap.GetCellCenterWorld(randomCell);
        // Check if the random position is valid (inside the tilemap)
        if (tilemapBounds.Contains(randomCell) && tilemap.GetTile(randomCell) != null)
        {
            enemy.transform.position = randomPosition;
            
        }
        else
        {
            // Try again if the position is invalid
            i--;
        }
    }
}

public void KillCount()
{
    Debug.Log("KillCount function called");
    int enemyKillCount = enemiesList.Count;
    print("Kills: " + enemyKillCount);
}


   public void AddDeadEnemy(EnemyHealth enemy)
    {
        enemiesList.Add(enemy); // Adicione o inimigo morto à lista
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

