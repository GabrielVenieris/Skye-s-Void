using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameLevel currentLevel;
    public int kills = 0;




    private GameLevel previousLevel; // Variável para armazenar o nível anterior

    public int enemiesPerLevel = 30;
    public int enemyHealth = 1;
    public int enemyDamage = 1;
    public int bossHealth = 1000;

    public bool lastEnemyIsABoss = false;


     void Awake()
    {
        if (instance == null)
            instance = this;
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

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
         string sceneName = SceneManager.GetActiveScene().name;

    switch (sceneName)
    {
        case "Mapa 1":
            currentLevel = GameLevel.Level1;
            SetupLevel(2);
            break;

        case "Mapa 2":
            currentLevel = GameLevel.Level2;
            SetupLevel(3);
            break;

        case "Mapa 3":
            currentLevel = GameLevel.Level3;
            SetupLevel(4);
            break;

        default:
            currentLevel = GameLevel.Level1; // Cena padrão
            SetupLevel(1);
            break;
    }
        // switch (currentLevel)
        // {
        //     case GameLevel.Level1:
        //     SetupLevel(2);
        //         break; // Define a quantidade de inimigos para o Level 1

        //     case GameLevel.Level2:
        //     SetupLevel(3);
        //         break; // Define a quantidade de inimigos para o Level 2

        //     case GameLevel.Level3:
        //     SetupLevel(4);
        //         break; // Define a quantidade de inimigos para o Level 3

        //     // Adicione outros casos para outros níveis
        //     default:
        //         break; // Se o nível não for reconhecido, retorne 0 inimigos
        // }
    }


     void CheckLevelCompleted()
{
    GameLevel current = currentLevel; // Armazene o nível atual antes da verificação

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
            GameManager.instance.LoadNextLevel();
            return; // Nível completo
        }
    }
    if (current != currentLevel)
    {
        // A cena mudou, chame SetupLevelChanged
        SetupLevelChanged();
    }
    return; // Nível não completo
}


void SetupLevel(int level) {
        kills = 0;
        enemiesPerLevel = 1 * (1+ ((level-1)/10));
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