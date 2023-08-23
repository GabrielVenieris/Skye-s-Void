using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausarJogo : MonoBehaviour
{
    public bool jogoPausado;

    // Referências para as imagens de pausa
    public Image imagemPausa1;
    public Image imagemPausa2;

    void Start()
    {
        Time.timeScale = 1f;
        jogoPausado = false;

        // Desativa as imagens de pausa no início
        imagemPausa1.gameObject.SetActive(false);
        imagemPausa2.gameObject.SetActive(false);
    }

    public void Pausar()
    {
        if (jogoPausado == false)
        {
            Time.timeScale = 0f;
            jogoPausado = true;

            // Ativa as imagens de pausa
            imagemPausa1.gameObject.SetActive(true);
            imagemPausa2.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            jogoPausado = false;

            // Desativa as imagens de pausa
            imagemPausa1.gameObject.SetActive(false);
            imagemPausa2.gameObject.SetActive(false);
        }
    }
}
