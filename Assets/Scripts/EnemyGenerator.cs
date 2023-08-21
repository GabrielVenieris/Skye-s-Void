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

    void Start()
    {
        float xDist = 0;
        for(int i = 0; i <= 3; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyChase>().player = playerTransform;
            enemy.transform.position = new Vector3(enemy.transform.position.x + xDist, enemy.transform.position.y, enemy.transform.position.z);
            xDist += xPadding;

            enemies.Add(enemy); // Add the instantiated enemy to the list
        }
    }

    void Update()
    {
        // Check if all enemies are destroyed
        if (AreAllEnemiesDestroyed())
        {
            SceneManager.LoadScene(0); // Load scene when all enemies are destroyed
        }
    }

    bool AreAllEnemiesDestroyed()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null) // If any enemy still exists, return false
            {
                return false;
            }
        }
        return true; // All enemies are destroyed
    }
}
