using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool hasFlipped = false;
    private bool isShootR = false;
    public int damage = 10; // Adicione a quantidade de dano aqui

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void SetIsShootingRight(bool value)
    {
        isShootR = value;
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f;
        anim.SetBool("ShootR", isShootR);

        if (rb.velocity.x < 0f && !hasFlipped)
        {
            sprite.transform.Rotate(0f, 180f, 0f);
            hasFlipped = true;
        }
        else if (rb.velocity.x > 0f && hasFlipped)
        {
            sprite.transform.Rotate(0f, 180f, 0f);
            hasFlipped = false;
        }
    }

    // Adicione este método para aplicar dano a um objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mob v2")) // Verifique a tag correta
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // Destrua o tiro após colidir com o inimigo
        }
    }
}
