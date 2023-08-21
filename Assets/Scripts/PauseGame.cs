using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Define a funcionalidade do botão de pouse: Muda o TimeScale pra 0, o que trava tudo o que ta acontecendo no game. 
*/

public class PausarJogo : MonoBehaviour
{
    // variável que nos permite verificar se o jogo está pausado ou não
    public bool jogoPausado;


    void Start()
    {
        // diz para a Unity rodar o jogo na velocidade normal
        Time.timeScale = 1f;       
        // diz para a Unity que o jogo não está pausado                     
        jogoPausado = false;                            
    }

    public void Pausar()
    {
        // verifica se o jogo não está pausado
        if(jogoPausado == false)
        {
            // diz para a Unity congelar a velocidade do jogo
            Time.timeScale = 0f; 
            // diz para a Unity que o jogo está pausado
            jogoPausado = true;                         
        }
        else    // verifica se o jogo está pausado
        {
            // diz para a Unity rodar o jogo na velocidade normal
            Time.timeScale = 1f;        
            // diz para a Unity que o jogo não está pausado                
            jogoPausado = false;                        
        }
    }
}