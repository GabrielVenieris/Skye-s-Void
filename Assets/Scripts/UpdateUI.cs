using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    public List<GameObject> collectedObjects = new List<GameObject>(); // Torna a lista pública

    private void LateUpdate()
    {
        int itemCount = collectedObjects.Count;
        UIText.text = "0" + itemCount;
    }
}
