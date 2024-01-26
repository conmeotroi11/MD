using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathVFXPrefabs;
    [SerializeField] private int startHealth;
    public int StartHealth => startHealth;
    private int currentHealth;
    public int CurrentHealth => currentHealth;
    private Knockback knockback; 
    private GetHitFlash GetHitFlash;
    [SerializeField] private float knockBackThurst;
    [SerializeField] private GameObject enemyObjectPooling;




    private void Awake()
    {
        GetHitFlash = GetComponent<GetHitFlash>(); 
        knockback = GetComponent<Knockback>();


    }

    private void Start()
    {
        currentHealth = startHealth; 
    }

    public void TakeDame(int damage) 
    {
        currentHealth -= damage;
        knockback.GetKnockBack(PlayerController.Instance.transform, knockBackThurst); 
        StartCoroutine(GetHitFlash.FlashRoutine()); 
        StartCoroutine(CheckEnemyDeathRoutine()); 

    }

    private IEnumerator CheckEnemyDeathRoutine() 
    {
        yield return new WaitForSeconds(GetHitFlash.GetRestoreMatTime()); 
        EnemyDeath();
    }
    public void EnemyDeath() 
    {
        if (currentHealth <= 0) 
        {
            GetComponent<PickUpSpawner>().DropItems();
            SFXManager.Instance.PlayAudio(10);
            Instantiate(deathVFXPrefabs, transform.position, Quaternion.identity);
            currentHealth = startHealth;
            foreach (Transform child in enemyObjectPooling.transform)
            {
                child.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);


        }
    }
}
