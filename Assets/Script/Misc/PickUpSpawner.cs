using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoinPrefab;
    [SerializeField] private int numberOfCoinsToSpawn;

    public void DropItems()
    {
        for (int i = 0; i < numberOfCoinsToSpawn; i++)
        {
            Instantiate(goldCoinPrefab, transform.position, Quaternion.identity);
        }
    }

}
