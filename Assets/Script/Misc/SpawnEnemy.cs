using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject summonVfx;
    [SerializeField] private GameObject colliderBlock;
    [SerializeField] private SpawnEnemyObjectPooling pool;
    [SerializeField] private List<GameObject> spawnPoint;
    private Collider2D coll;
    private bool enemiesSpawned = false;

    [System.Serializable]
    public class EnemySpawnInfo
    {
        public int enemyType;
        public int spawnCount;
    }

    [SerializeField] private List<EnemySpawnInfo> enemiesToSpawn;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (enemiesSpawned)
        {
            if (pool.AreAllPooledObjectsInactive())
            {
                Destroy(colliderBlock);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !enemiesSpawned)
        {
            SFXManager.Instance.PlayAudio(9);
            colliderBlock.SetActive(true);

            foreach (EnemySpawnInfo enemyInfo in enemiesToSpawn)
            {
                for (int i = 0; i < enemyInfo.spawnCount; i++)
                {
                    GameObject pooledObject = pool.GetPooledObject(enemyInfo.enemyType);
                    pooledObject.transform.position = spawnPoint[i].transform.position;
                    pooledObject.SetActive(true);
                    Instantiate(summonVfx, pooledObject.transform.position, Quaternion.identity);
                }
            }

            enemiesSpawned = true;
            coll.enabled = false;
        }
    }
}