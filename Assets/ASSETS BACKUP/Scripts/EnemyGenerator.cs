using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform playerTransform;
    public float xPadding;

    void Start()
    {
        float xDist = 0;
        for(int i =0 ; i<=10; i++){
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyChase>().player = playerTransform;
            enemy.transform.position = new Vector3(enemy.transform.position.x + xDist, enemy.transform.position.y, enemy.transform.position.z);
            xDist+=xPadding;
        }
    }
}