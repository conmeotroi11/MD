using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneEnemyFireAttack : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject enemyFireAttackVFXDeath;
  
    void Update()
    {
        MoveProjectile();
    }
    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.CompareTag("Player")) 
        {
            PlayerHealth.Instance.TakeDame(damageAmount, transform);
            Instantiate(enemyFireAttackVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(7);
            Destroy(gameObject);
        }

        if (collision.transform.CompareTag("Collider"))
        {
            Instantiate(enemyFireAttackVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(7);
            Destroy(gameObject);
        }

    }
}