using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Define o que o botão PLAY faz: Vai pra cena 1(Cena do jogo)
Starta o TimeCounter(Cronômetro do jogo)
*/


public class MainMenu : MonoBehaviour
{
    
    public void PlayGame ()
    {
        FindAnyObjectByType<GameManager>().LoadNextLevel();
        TimeCounter.sceneStarted = true;
    }




}
