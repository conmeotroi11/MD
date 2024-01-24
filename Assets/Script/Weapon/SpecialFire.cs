﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class SpecialFire : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject fireVFXDeath;
    [SerializeField] private GameObject firePrefab;


    void Update()
    {
        MoveFire();
    }
    private void MoveFire()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Vector3 nearestEnemyPosition = FindNearestEnemyPosition(transform.position, collision.transform);
            Vector3 spawnFire = nearestEnemyPosition - collision.transform.position;
            GameObject newFire = Instantiate(firePrefab, transform.position, Quaternion.identity);
            newFire.transform.right = spawnFire;
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDame(damageAmount);
            Instantiate(fireVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(1);
            this.gameObject.SetActive(false);
        }

        if (collision.transform.CompareTag("Collider"))
        {
            Instantiate(fireVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(1);
            gameObject.SetActive(false);
        }
    }

    private Vector3 FindNearestEnemyPosition(Vector3 currentPosition, Transform currentEnemy)
    {
        float radius = 20f; 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(currentPosition, radius);

        Vector3 nearestPosition = Vector3.zero;
        float nearestDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy") && collider.transform != currentEnemy)
            {
                float distance = Vector3.Distance(currentPosition, collider.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestPosition = collider.transform.position;
                }
            }
        }

        return nearestPosition;
    }

}


