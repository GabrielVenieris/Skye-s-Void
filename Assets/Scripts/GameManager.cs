using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Singleton
Define a organização do jogo: Ainda incompleto(fora de funcionamento)
BackToMenu() = Volta pra tela de inicio
*/

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    // public GameObject gameMusic;



    void Awake() 
    {
        if (instance == null)
            instance = this;
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        // gameMusic = GameObject.Find("GameMusic"); // Encontre o objeto GameMusic

    }

    // void Start()
    // {
    //     // Verifique se a cena atual não é a "StartMenuScene"
    //     if (SceneManager.GetActiveScene().name != "StartMenuScene")
    //     {
    //         // Verifique se o objeto GameMusic existe
    //         if (gameMusic != null)
    //         {
    //             // Reproduza a música no objeto GameMusic
    //             AudioSource audioSource = gameMusic.GetComponent<AudioSource>();
    //             if (audioSource != null)
    //             {
    //                 audioSource.Play();
    //             }
    //         }
    //     }
    // }


    public void UpdateGameStates(GameState newState)
    {

        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.NextLevel:
                break;
            case GameState.GoingToTheVoid:
                break;
            case GameState.Pause:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }


        OnGameStateChanged?.Invoke(newState);
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    
public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    


}

public enum GameState
{
    MainMenu,
    NextLevel,
    GoingToTheVoid,
    Pause,
    Lose,
}
