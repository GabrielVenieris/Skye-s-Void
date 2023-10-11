using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Define a funcionalidade do botão de pouse: Muda o TimeScale pra 0, o que trava tudo o que ta acontecendo no game. 
*/

public class PausarJogo : MonoBehaviour
{
    public bool jogoPausado;
    public GameObject PauseUI;
    public GameObject BlackBackground;
    public GameObject Joystick;
    public GameManager GameManager;

    void Start()
    {
        Time.timeScale = 1f;
        jogoPausado = false;
        AtualizarVisibilidadePauseUI();
        AtualizarVisibilidadeJoystick();
    }

    public void PausarOuContinuar()
    {
        jogoPausado = !jogoPausado;
        Time.timeScale = jogoPausado ? 0f : 1f;
        AtualizarVisibilidadePauseUI();
        AtualizarVisibilidadeJoystick();
    }

    public void AtualizarVisibilidadePauseUI()
    {
        PauseUI.SetActive(jogoPausado);
        BlackBackground.SetActive(jogoPausado);
    }

    public void AtualizarVisibilidadeJoystick()
    {
        Joystick.SetActive(!jogoPausado); // Define a visibilidade do Joystick com base no estado do jogo pausado
    }


    public void BackToMenu()
    {
        FindAnyObjectByType<GameManager>().BackToMenu();
    }


}
