using System.Collections;
using System.Collections.Generic;
using System.Security;
using JetBrains.Annotations;
using UnityEngine;

/*
Define as especificações da bala: Colisão, animação, tempo de vida, dano, espelhamento de animação. Com inimigos normais e com bosses.
*/

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool hasFlipped = false;
    private bool isShootR = false;
    public int damage = 10;
    public float lifeTime = 2.0f; // Tempo de vida do tiro em segundos
    public GameObject impactEffect;

    public bool Seeking;
    public Vector3 seekingPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        // Destrua o tiro após um certo tempo
        Destroy(gameObject, lifeTime);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mob v2"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("VoidBoss"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            if(enemyHealth.health == 0 )
            {
                GameManager.Instance.LoadNextLevel();
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }



    }


}
