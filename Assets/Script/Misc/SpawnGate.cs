using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    private int enemyIndex;
    public int EnemyIndex { get { return enemyIndex; } set { enemyIndex = value; } }
    [SerializeField] private EnemyCountData enemyCountData;


    void Update()
    {
       if(enemyIndex >= enemyCountData.enemyCount)
        {
            gate.SetActive(true);
        }

    }
}