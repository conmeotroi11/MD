using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyObjectPooling : MonoBehaviour
{
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private List<int> pooledAmounts;

    List<List<GameObject>> pooledObjectList;

    void Start()
    {
        int totalPooledObjects = 0;
        int typesCount = pooledObjects.Count;

        // Calculate total number of pooled objects
        for (int i = 0; i < typesCount; i++)
        {
            totalPooledObjects += pooledAmounts[i];
        }

        pooledObjectList = new List<List<GameObject>>(typesCount);

        for (int i = 0; i < typesCount; i++)
        {
            pooledObjectList.Add(new List<GameObject>());

            for (int j = 0; j < pooledAmounts[i]; j++)
            {
                GameObject obj = Instantiate(pooledObjects[i]);
                obj.SetActive(false);
                obj.transform.SetParent(transform);
                pooledObjectList[i].Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(int type)
    {
        for (int i = 0; i < pooledObjectList[type].Count; i++)
        {
            if (!pooledObjectList[type][i].activeInHierarchy && pooledObjectList[type][i] != null)
            {
                return pooledObjectList[type][i];
            }
        }

        GameObject obj = Instantiate(pooledObjects[type]);
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pooledObjectList[type].Add(obj);
        return obj;
    }

    public bool AreAllPooledObjectsInactive()
    {
        for (int i = 0; i < pooledObjectList.Count; i++)
        {
            for (int j = 0; j < pooledObjectList[i].Count; j++)
            {
                if (pooledObjectList[i][j].activeInHierarchy)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
