using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class QuestEvent : MonoBehaviour
{
    public static event Action DefeatEnemy;
    [SerializeField] private List<GameObject> enemies;
    private List<GameObject> checkedEnemies = new List<GameObject>();
    private int enemiesDefeatedCount;

    void Update()
    {
        foreach (GameObject enemy in enemies)
        {

            if (enemy == null && !checkedEnemies.Contains(enemy))
            {
                enemiesDefeatedCount++;
                SaveCountEnemies();
                checkedEnemies.Add(enemy); 
            }
        }

        if (enemiesDefeatedCount == 10)
        {
            DefeatEnemy?.Invoke();
        }
        LoadCountEnemies();
    }

    private void SaveCountEnemies()
    {
        PlayerPrefs.SetInt("Enimies", enemiesDefeatedCount);
    }

    private void LoadCountEnemies()
    {
        enemiesDefeatedCount = PlayerPrefs.GetInt("Enimies");
    }
}
