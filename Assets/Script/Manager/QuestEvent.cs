using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent : MonoBehaviour
{
    public static event Action FirstQuestCheck;
    [SerializeField] private SpawnGate spawnGate;
    [SerializeField] private int enemyCount;
   


    void Update()
    {
        if( enemyCount <= spawnGate.EnemyIndex )
        {
            FirstQuestCheck?.Invoke();
        }
    }
}
