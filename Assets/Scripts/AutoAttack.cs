using UnityEngine;

public class AutoAttack : MonoBehaviour
    {
    public float attackRadius = 1.5f; // Raio da área de ataque
    public LayerMask enemyLayer; // Camada dos inimigos
    public int damage = 10;



    private void Update()
    {
        // Detecta inimigos automaticamente quando entram na área de ataque
        DetectEnemies();
    }

    void OnDrawGizmosSelected()
    {
        // Desenha a área de ataque ao redor do personagem na cena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    void DetectEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

        if (hitEnemies.Length > 0)
        {
            Attack(hitEnemies);
        }
    }

    void Attack(Collider2D[] enemies)
    {
        // Coloque aqui a lógica para causar dano aos inimigos, se necessário
        foreach (Collider2D enemyCollider in enemies)
        {
            // Verifique se o objeto tem a tag "Enemy"
            if (enemyCollider.CompareTag("Enemy"))
            {
                // Adicione lógica para causar dano ao inimigo, por exemplo:
                EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }

        // Aciona a animação de ataque
        GetComponent<Animator>().SetBool("Slash", true);
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Mob v2"))
    //     {
    //         EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
    //         if (enemyHealth != null)
    //         {
    //             enemyHealth.TakeDamage(damage);
    //         }
    //         Instantiate(impactEffect, transform.position, transform.rotation);
    //         Destroy(gameObject);
    //     }
    // }
}