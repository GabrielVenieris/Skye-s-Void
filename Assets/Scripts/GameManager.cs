using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Singleton
Define a organização do jogo: Ainda incompleto(fora de funcionamento)
BackToMenu() = Volta pra tela de inicio
Define animacao de troca de tela(fade_in/out)
*/

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public Animator transition;
    public float transitionTime = 1f;



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
        // SceneManager.LoadScene(0);
        //Menu = LevelIndex 0
        StartCoroutine(LoadNextLevelFade(1));
       
    }

    
    public void LoadNextLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadNextLevelFade(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadNextLevelFade(int levelIndex)
    {
        transition.SetTrigger("StartFade");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        // transition.SetTrigger("StartFade");
        transition.ResetTrigger("StartFade");
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
