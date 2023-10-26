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
        //FIXME: Não ta chamando GameManager: Compromete o fadeIn/Out;
        // SceneManager.LoadScene(2);
        FindAnyObjectByType<GameManager>().LoadNext2Level();
        TimeCounter.sceneStarted = true;
    }




}
