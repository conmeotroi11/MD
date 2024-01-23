using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NercomancerEnemyFireAttack : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject enemyFireAttackVFXDeath;
    [SerializeField] private GameObject FireAttackVFXDeath;
    [SerializeField] private int burstCount;
    [SerializeField] private float maxDistance;
    private float distanceTraveled;

    void Update()
    {
        MoveProjectile();
    }
    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        distanceTraveled += moveSpeed * Time.deltaTime;

        if (distanceTraveled >= maxDistance)
        {
            Burst();
            distanceTraveled = 0;
        }
    }
    private void Burst()
    {
        float angleStep = 360f / burstCount;

        for (int i = 0; i < burstCount; i++)
        {
            float angle = i * angleStep;
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
            Instantiate(FireAttackVFXDeath, transform.position, Quaternion.LookRotation(Vector3.forward, direction));
            Destroy(gameObject);
        }
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
            Burst();
            Instantiate(enemyFireAttackVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(7);
            Destroy(gameObject);
        }

    }
}