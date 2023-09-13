using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject bulletPrefab; // Prefab do tiro
    public Transform firePoint; // Posição de onde os tiros serão disparados
    public float bulletSpeed = 10f; // Velocidade dos tiros
    public MovementJoystick movementJoystick; // Referência ao joystick
    public float fireInterval = 5000f; // Intervalo entre os tiros em segundos
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
        // Vector2 shootingDirection = movementJoystick.joystickVec.normalized;

        // // Verifica se o joystick está sendo movido (não está na posição neutra)
        // if (shootingDirection != Vector2.zero)
        // {
        //     Shoot(shootingDirection);
        //      timeSinceLastShot = 0f; // Reinicia o contador de tempo desde o último disparo
        // }
        BulletSeek();
        timeSinceLastShot = 0f; // Reinicia o contador de tempo desde o último disparo
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

public void ShootSeek(Transform enemy)
{
    // Cria um tiro a partir do prefab e define sua posição no ponto de disparo e rotação
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

    // Obtém o componente Rigidbody2D do tiro e aplica a velocidade para a direção calculada
    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
    Vector3 direction = enemy.position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    bulletRb.velocity = direction.normalized * bulletSpeed;
    
}

public void BulletSeek(){
    RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 3f, -Vector2.up, 3f, LayerMask.GetMask("Enemy"));
    RaycastHit2D[] hitBoss = Physics2D.CircleCastAll(transform.position, 3f, -Vector2.up, 3f, LayerMask.GetMask("Boss"));
    if(hit.Length > 0){

        // // atira em todo mundo 
        // foreach( RaycastHit2D enemy in hit){
        //      ShootSeek(enemy.collider.transform);
        // }

        //atira em um qualquer ideal seria o mais próximo
        ShootSeek(hit[0].collider.transform); 
        ShootSeek(hitBoss[0].collider.transform);
    }
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

 private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

}