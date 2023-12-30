using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject summonVfx;
    [SerializeField] private GameObject colliderBlock;
    private Collider2D coll;


    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }


    private void Update()
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
            Destroy(colliderBlock);
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemies)
            {
                SFXManager.Instance.PlayAudio(9);
                colliderBlock.SetActive(true);
                Instantiate(summonVfx, enemy.transform.position, Quaternion.identity);
                enemy.SetActive(true);
                coll.enabled = false;
            }
        }

        
    }
    
}
