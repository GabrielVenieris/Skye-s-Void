using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public GameObject tilemapObject;
    public List<EnemyHealth> enemiesKilledList = new List<EnemyHealth>();


    [SerializeField] private float spawnRate = 1f;
    private float currentSpawnInterval;
    private float timer = 0.0f;
    private Tilemap tilemap;
    // uma private void para o Mapa2, para que a segunda cena consiga acessar
    private BoundsInt tilemapBounds;
    private LevelManager levelManager;
    private int enemiesToSpawn;


    void Start()
    {
        InitializeReferences();
        enemiesToSpawn = levelManager.enemiesPerLevel;
        StartCoroutine(SpawnEnemies(enemiesToSpawn));
    }

    void Update()
    {
        KillCount();
        timer += Time.deltaTime;
    }

    private void InitializeReferences()
    {
        tilemap = tilemapObject.GetComponent<Tilemap>();
        tilemapBounds = tilemap.cellBounds;
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("Level Manager não encontrado.");
        }
    }

    private IEnumerator SpawnEnemies(int x)
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        for (int i = 0; i < x; i++)
        {
            yield return wait;
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyChase>().player = playerTransform;

            Vector3Int randomCell = new Vector3Int(
                Random.Range(tilemapBounds.xMin, tilemapBounds.xMax),
                Random.Range(tilemapBounds.yMin, tilemapBounds.yMax),
                0);

            Vector3 randomPosition = tilemap.GetCellCenterWorld(randomCell);

            if (tilemapBounds.Contains(randomCell) && tilemap.GetTile(randomCell) != null)
            {
                enemy.transform.position = randomPosition;
            }
            else
            {
                i--;
            }
        }
    }

    public void KillCount()
    {
        Debug.Log("KillCount function called");
        int enemyKillCount = enemiesKilledList.Count;
        print("Kills: " + enemyKillCount);
    }

    public void AddDeadEnemy(EnemyHealth enemy)
    {
        enemiesKilledList.Add(enemy);
    }

    public List<EnemyHealth> GetEnemiesKilledList()
    {
        return enemiesKilledList;
    }
}










/*
Define quantidade de inimigos na cena. Cria uma lista de inimigos e quando chega a zero(morrem todos) o jogo reinicia
*/


//IMPORTANTE PARA SABER SE JÁ PODE IR PRA PRÓXIMA ILHA
        // // Check if all enemies are destroyed
        // if (AreAllEnemiesDestroyed())
        // {
        //     SceneManager.LoadScene(0); // Load scene when all enemies are destroyed
        // }

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