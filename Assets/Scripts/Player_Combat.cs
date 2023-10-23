using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public float attackInterval = 2f; // Intervalo entre ataques
    public Animator animator;

    private float lastAttackTime;

    void Update()
    {
        // Verifica se o cooldown terminou
        if (Time.time - lastAttackTime > attackInterval)
        {
            // Coloque aqui a lógica para causar dano aos inimigos, se necessário

            // Define a animação de ataque na sua personagem aqui (usando Animator ou outra lógica)
            animator.SetTrigger("Attack");

            // Atualiza o tempo do último ataque
            lastAttackTime = Time.time;
        }
    }
}
