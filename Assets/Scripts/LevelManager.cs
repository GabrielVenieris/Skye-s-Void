using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                return 5; // Define a quantidade de inimigos para o Level 1
            case GameLevel.Level2:
                return 35; // Define a quantidade de inimigos para o Level 2
            case GameLevel.Level3:
                return 50; // Define a quantidade de inimigos para o Level 3
            // Adicione outros casos para outros níveis
            default:
                return 0; // Se o nível não for reconhecido, retorne 0 inimigos
        }
    }





}



public enum GameLevel
{
    Level1,
    Level2,
    Level3,
}