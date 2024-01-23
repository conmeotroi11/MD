using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButcherEnemyFireAttack : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject enemyFireAttackVFXDeath;
    [SerializeField] private float maxDistance; 
    [SerializeField] private float destroyDistance;

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
            moveSpeed *= -1; 
            distanceTraveled = 0; 
        }
        if (Mathf.Abs(distanceTraveled) >= destroyDistance)
        {
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
            Instantiate(enemyFireAttackVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(7);
            Destroy(gameObject);
        }
      

    }
}