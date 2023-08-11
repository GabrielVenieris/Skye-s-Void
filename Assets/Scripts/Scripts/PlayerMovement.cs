using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float moveSpeed = 3f;
    private float jumpForce = 14f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Captura a entrada do teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Captura a posição do cursor do mouse ou toque na tela
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcula a direção do personagem em relação ao cursor/touch
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize(); // Normaliza para ter apenas a direção, sem a magnitude

        // Atualiza a velocidade do Rigidbody2D com base na entrada do teclado e direção do cursor/touch
        rb.velocity = new Vector2(moveHorizontal * moveSpeed + direction.x * moveSpeed, moveVertical * moveSpeed + direction.y * moveSpeed);

        // Atualiza as animações de movimentação
        UpdateAnimation();

        // Verifica se o jogador pressionou a tecla de pulo (espaço)
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimation()
    {
        // Define a animação de corrida com base na direção horizontal do movimento
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f;
        anim.SetBool("running", isRunning);

        // Inverte a sprite horizontalmente se estiver se movendo para a esquerda
        if (rb.velocity.x > 0f)
        {
            sprite.flipX = false;
        }
        else if (rb.velocity.x < 0f)
        {
            sprite.flipX = true;
        }
    }
}