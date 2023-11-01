using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Define a velocidade, mudança de animação dos inimigos...
*/

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void Update()
    {
        // Verifica se o jogador existe (caso tenha sido destruído)
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;

            // Rotação do inimigo para olhar na direção do jogador
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // Atualiza as animações de movimentação
            UpdateAnimation();
        }
        else
        {
            // Caso o jogador tenha sido destruído ou não exista mais, o inimigo para de se mover.
            rb.velocity = Vector2.zero;
        }
    }

    private void UpdateAnimation()
    {
        // Define a animação de corrida com base na direção horizontal do movimento
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f;
        anim.SetBool("run", isRunning);

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