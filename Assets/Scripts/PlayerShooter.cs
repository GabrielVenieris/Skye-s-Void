using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject bulletPrefab; // Prefab do tiro
    public Transform firePoint; // Posição de onde os tiros serão disparados
    public float bulletSpeed = 10f; // Velocidade dos tiros
    public MovementJoystick movementJoystick; // Referência ao joystick
    public float fireInterval = 0.5f; // Intervalo entre os tiros em segundos
    private float timeSinceLastShot = 0f;
    private SpriteRenderer sprite;
    private Animator anim;




    // Update is called once per frame
  void Update()
{
    timeSinceLastShot += Time.deltaTime;

    // Verifica se o tempo entre os tiros passou
    if (timeSinceLastShot >= fireInterval)
    {
        // Calcula a direção do tiro baseado na direção atual do joystick do PlayerMover
        Vector2 shootingDirection = movementJoystick.joystickVec.normalized;

        // Verifica se o joystick está sendo movido (não está na posição neutra)
        if (shootingDirection != Vector2.zero)
        {
            Shoot(shootingDirection);
            timeSinceLastShot = 0f; // Reinicia o contador de tempo desde o último disparo
        }
    }
}


public void Shoot(Vector2 shootingDirection)
{
    // Cria um tiro a partir do prefab e define sua posição no ponto de disparo e rotação
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

    // Obtém o componente Rigidbody2D do tiro e aplica a velocidade para a direção calculada
    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
    bulletRb.velocity = shootingDirection * bulletSpeed;


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