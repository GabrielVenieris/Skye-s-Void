using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    public MovementJoystick movementJoystick; // Referência ao joystick
    public float playerSpeed = 3f;
    private float jumpForce = 14f;
    public PlayerShooter playerShooter; // Referência ao script PlayerShooter
    private bool hasFlipped = false; // Variável para controlar se a sprite já foi virada

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
        // Captura a entrada do joystick
        Vector2 moveInput = new Vector2(movementJoystick.joystickVec.x, movementJoystick.joystickVec.y);
        Vector2 moveVelocity = moveInput.normalized * playerSpeed;
        rb.velocity = moveVelocity;

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
        if (rb.velocity.x < 0f && !hasFlipped)
        {
            sprite.transform.Rotate(0f, 180f, 0f);
            hasFlipped = true; // Marca que a sprite foi virada
        }
        else if (rb.velocity.x > 0f && hasFlipped) // Reset da flag se mudar de direção
        {
            sprite.transform.Rotate(0f, 180f, 0f);
            hasFlipped = false;
        }
    }


}
