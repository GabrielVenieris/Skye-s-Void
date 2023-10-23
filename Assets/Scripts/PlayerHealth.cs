using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Healthbar healthBar;
    public GameManager GameManager;

    public float blinkDuration = 0.1f; // Duração de cada piscada
    public float blinkInterval = 0.2f; // Intervalo entre piscadas
    public int blinkCount = 1; // Número de piscadas após receber dano
    private bool isBlinking = false;
    private Renderer playerRenderer; // Ou SpriteRenderer, dependendo do tipo de renderizador do jogador

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        playerRenderer = GetComponent<Renderer>(); // Ou GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkEffect());
            health -= amount;
            healthBar.SetHealth(health);
            if (health <= 0)
            {
                // Verifique a cena atual
                string currentScene = SceneManager.GetActiveScene().name;

                // Use uma instrução switch para decidir para qual cena ir com base na cena atual
                switch (currentScene)
                {
                    case "Void":
                        SceneManager.LoadScene(0); // Menu = LevelIndex 0
                        break;
                    default:
                        SceneManager.LoadScene("Void"); // Carregue a cena chamada "Void"
                        break;
                }
                // GameManager.BackToMenu();
                TimeCounter.sceneStarted = false;
            }
        }
    }

    private IEnumerator BlinkEffect()
    {
        isBlinking = true;
        Color originalColor = playerRenderer.material.color; // Ou playerRenderer.color para SpriteRenderer
        Color transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Piscar apenas o número definido de vezes após receber dano
        for (int i = 0; i < blinkCount; i++)
        {
            playerRenderer.material.color = transparentColor; // Ou playerRenderer.color para SpriteRenderer
            yield return new WaitForSeconds(blinkDuration);

            playerRenderer.material.color = originalColor; // Ou playerRenderer.color para SpriteRenderer
            yield return new WaitForSeconds(blinkDuration);

            yield return new WaitForSeconds(blinkInterval);
        }

        // Garanta que a cor do renderizador seja restaurada ao seu valor original após piscar
        playerRenderer.material.color = originalColor; // Ou playerRenderer.color para SpriteRenderer

        isBlinking = false;
    }
}
