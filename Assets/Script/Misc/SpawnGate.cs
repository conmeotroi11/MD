using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    [SerializeField] private List<GameObject> enemies;

    void Update()
    {
        bool allEnemiesDestroyed = true;

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
              
                allEnemiesDestroyed = false;
                break;
            }
        }

       
        if (allEnemiesDestroyed)
        {
            gate.SetActive(true);
        }
    }
}