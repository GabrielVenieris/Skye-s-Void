using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float attackRadius = 3f; // Raio de detecção de ataque

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool playerInRange = false;
    private bool isAttacking;
    private float attackTime = 1f;
    private int attackValue = 1;

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
            // Verifica se o jogador está dentro do alcance de ataque
            if (Vector2.Distance(transform.position, player.position) <= attackRadius)
            {
                // Ativa o gatilho "Attack" na animação
                anim.SetBool("Attack", true);

                // Implemente o comportamento de ataque aqui
                Debug.Log("Ataque!");

                // Você pode adicionar mais lógica de ataque aqui, como causar dano ao jogador, por exemplo
                if (!isAttacking)
                    StartCoroutine("EvaluateAttack");
            }
            else
            {
                // Se o jogador estiver fora do alcance de ataque, mova-se em direção a ele
                Vector2 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * speed;

                // Desativa o gatilho "Attack" na animação e ativa o Keeper_Float
                anim.SetBool("Attack", false);
                anim.SetBool("Keeper_Float", true);

                // Atualiza as animações de movimentação
                UpdateAnimation();
            }
        }
        else
        {
            // Caso o jogador tenha sido destruído ou não exista mais, o inimigo para de se mover.
            rb.velocity = Vector2.zero;
        }
    }

    public IEnumerator EvaluateAttack()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackTime);

        // Verifica se o jogador ainda está dentro do alcance de ataque após o tempo de ataque
        if (Vector2.Distance(transform.position, player.position) <= attackRadius)
        {
            // Ataque ao jogador
            player.GetComponent<PlayerHealth>().TakeDamage(attackValue);
        }
        

        isAttacking = false;
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