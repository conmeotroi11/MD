using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damageAmount;
    [SerializeField] private GameObject fireVFXDeath;

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
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDame(damageAmount);
            Instantiate(fireVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(1);
            gameObject.SetActive(false);
        }

        if (collision.transform.CompareTag("Collider"))
        {
            Instantiate(fireVFXDeath, transform.position, transform.rotation);
            SFXManager.Instance.PlayAudio(1);
            gameObject.SetActive(false);
        }
    }
}
