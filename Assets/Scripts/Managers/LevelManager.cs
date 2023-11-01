using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameLevel currentLevel;
    public int kills = 0;



    public int enemiesPerLevel;
    public int enemyHealth;
    public int enemyDamage;
    public int bossHealth;

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
    }


     void CheckLevelCompleted()
{
    GameLevel current = currentLevel; // Armazene o nível atual antes da verificação
    //Verifica quem é a próxima cena
    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

    EnemyGenerator enemyGenerator = FindObjectOfType<EnemyGenerator>();
    if (enemyGenerator != null)
    {
        List<EnemyHealth> playerKillsList = enemyGenerator.GetEnemiesKilledList(); 
 
        
        // Verifique se a próxima cena existe
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Verifique se a quantidade de inimigos mortos é igual à quantidade de inimigos a serem spawnados
            if (playerKillsList.Count == enemiesPerLevel)
            {
                // Há uma próxima cena, então vá para ela usando o GameManager
                GameManager.instance.LoadNextLevel();
                 // A cena mudou, chame SetupLevelChanged
                SetupLevelChanged();
            }
            
            return; // Nível completo
            
        } else if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                // Não há próxima cena, ou seja, você está na última fase
                Debug.Log("Você está na última fase!");
                enemiesPerLevel = 10000;
                 
            }
    }
}


void SetupLevel(int level) {

                kills = 0;
                enemiesPerLevel = Mathf.FloorToInt(level * 10);
                enemyHealth = Mathf.FloorToInt(level * 10);
                enemyDamage = Mathf.FloorToInt(1 * (10 + ((level - 1) / 10)));
                lastEnemyIsABoss = (level == 3);

}


}



public enum GameLevel
{
    Level1,
    Level2,
    Level3,
}