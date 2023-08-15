using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float minX, maxX, minY, maxY;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//Não esquecer tag player as tag
    }

    private void LateUpdate()
    {
        // Primeiro Método, tradicional de movimentação de câmera
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //Segundo Método, movimento suave
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), smoothSpeed * Time.deltaTime);

        // //Limite da câmera
        // transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), //x limite
        //                                  Mathf.Clamp(transform.position.y, minY, maxY), // y limite
        //                                  transform.position.z);

    }

}
