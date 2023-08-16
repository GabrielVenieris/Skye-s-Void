using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJogo : MonoBehaviour
{
    // variável que nos permite verificar se o jogo está pausado ou não
    public bool jogoPausado;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;                            // diz para a Unity rodar o jogo na velocidade normal
        jogoPausado = false;                            // diz para a Unity que o jogo não está pausado
    }

    // Update is called once per frame
    // void Update()
    // {
        

    // }

    public void Pausar()
    {
        // verifica se o jogo não está pausado
        if(jogoPausado == false)
        {
            Time.timeScale = 0f;                        // diz para a Unity congelar a velocidade do jogo
            jogoPausado = true;                         // diz para a Unity que o jogo está pausado
        }
        else    // verifica se o jogo está pausado
        {
            Time.timeScale = 1f;                        // diz para a Unity rodar o jogo na velocidade normal
            jogoPausado = false;                        // diz para a Unity que o jogo não está pausado
        }
    }

    public void click()
    {
        Debug.Log("clicado");
    }

}