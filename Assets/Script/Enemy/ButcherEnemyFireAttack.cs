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
    [SerializeField] private float speedDecreaseRate;

    private float distanceTraveled;
    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

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
            moveSpeed = -20;
            distanceTraveled = 0;
        }
        if (Mathf.Abs(distanceTraveled) >= destroyDistance)
        {
            ResetFire();
            
            
        }
        moveSpeed -= speedDecreaseRate * Time.deltaTime;

 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeDame(damageAmount, transform);
            Instantiate(enemyFireAttackVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(7);
            ResetFire();
            
        }

        if (collision.transform.CompareTag("Collider"))
        {
            Instantiate(enemyFireAttackVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(7);
            ResetFire();
            
        }

       


    }

    private void ResetFire()
    {
        moveSpeed = 20;
        distanceTraveled = 0;
        gameObject.SetActive(false);
    }
}