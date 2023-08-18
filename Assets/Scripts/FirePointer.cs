using UnityEngine;

public class FirePointRotator : MonoBehaviour
{
    private bool isFacingRight = true; // Inicialmente assume que a personagem está virada para a direita
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        // Inicializa a direção do jogador com base na posição inicial
        isFacingRight = transform.parent.localScale.x > 0f;
    }

    private void Update()
    {
        // Atualiza a direção do jogador com base na escala do pai (personagem)
        isFacingRight = transform.parent.localScale.x > 0f;

        // Rotaciona o firePoint em 180 graus se a direção estiver para a esquerda
        if (!isFacingRight)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            // Se a direção estiver para a direita, mantém a rotação padrão
            transform.localRotation = Quaternion.identity;
        }

        // Atualiza a variável de animação "running" no Animator com base no movimento
        bool isRunning = Mathf.Abs(anim.GetComponent<Rigidbody2D>().velocity.x) > 0.1f || Mathf.Abs(anim.GetComponent<Rigidbody2D>().velocity.y) > 0.1f;
        anim.SetBool("running", isRunning);
    }
}
