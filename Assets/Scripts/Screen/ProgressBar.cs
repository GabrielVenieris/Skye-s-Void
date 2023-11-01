using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int min;
    public int max;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        EnemyGenerator enemyGenerator = FindObjectOfType<EnemyGenerator>();
        List<EnemyHealth> playerKillsList = enemyGenerator.GetEnemiesKilledList();

        max = FindAnyObjectByType<LevelManager>().enemiesPerLevel;
        current = playerKillsList.Count;
        
        getCurrentFill();
    }

    void getCurrentFill()
    {
        float currentOffSet = current - min;
        float maximumOffSet = max - min;
        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }



}
