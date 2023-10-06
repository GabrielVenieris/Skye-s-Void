// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SlashAttack : MonoBehaviour
// {
//     private Animator animator;
//     public LayerMask enemyLayer; // A camada dos inimigos
//     public float attackRadius = 1.5f; // Raio da área de ataque
//     public int attackDamage = 1; // Dano do ataque

//     // Mova a declaração do array para o escopo da classe
//     private Collider2D[] hitEnemies;

//     private void Start()
//     {
//         animator = GetComponent<Animator>();
//     }

//     private void Update()
//     {
//         // Detecta inimigos automaticamente quando entram na área de ataque
//         DetectEnemies();
//     }

//     // Método para detectar inimigos e acionar o ataque automaticamente
//     private void DetectEnemies()
//     {
//         // Realize um circle cast para detectar inimigos na área de ataque
//         hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

//         // Se houver inimigos na área, acione o ataque automaticamente
//         if (hitEnemies.Length > 0)
//         {
//             Attack();
//         }
//     }

//     // Método para acionar o ataque e causar dano aos inimigos
//     private void Attack()
//     {
//         // Aciona o trigger de ataque na animação
//         animator.SetTrigger("AttackTrigger");

//         // Cause dano aos inimigos detectados
//         foreach (Collider2D enemy in hitEnemies)
//         {
//             // Adicione lógica para causar dano ao inimigo, por exemplo:
//             enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
//         }
//     }
// }





