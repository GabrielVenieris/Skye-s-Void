using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    [SerializeField] private GameObject ObjectPrefab;
    private UpdateUI updateUI;

    private void Awake()
    {
        updateUI = FindObjectOfType<UpdateUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Adiciona o objeto coletado à lista na UI
            updateUI.collectedObjects.Add(ObjectPrefab);
            Destroy(gameObject);
        }
    }
}
