using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    public List<GameObject> collectedObjects = new List<GameObject>(); // Torna a lista pública
    public int coinsForAreaAttack = 5; // Número de moedas para acionar a animação de ataque em área

    private void LateUpdate()
    {
        int itemCount = collectedObjects.Count;
        UIText.text = "0" + itemCount;

        // Verifica se o número de moedas atingiu o limite para a animação de ataque em área
        if (itemCount >= coinsForAreaAttack)
        {
            TriggerAreaAttack();
        }
    }

    private void TriggerAreaAttack()
    {
        // Adicione aqui o código para acionar a animação de ataque em área
        Debug.Log("Área de ataque acionada!");
        // Reset o contador ou faça outras ações necessárias após a animação
        collectedObjects.Clear();
    }
}
