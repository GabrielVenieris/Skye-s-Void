using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

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

}

public enum GameState
{
    MainMenu,
    NextLevel,
    GoingToTheVoid,
    Pause,
    Lose,
}
