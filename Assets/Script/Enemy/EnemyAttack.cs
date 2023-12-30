using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int burstCount;
    [SerializeField] private float timeBetweenBurst;
    [SerializeField] private float restTime;
    private bool isShooting = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        if (!isShooting)
        {
            
            StartCoroutine(ShootRoutine());
            

        }
    }
    private IEnumerator ShootRoutine()
    {
        isShooting = true;
        for (int i = 0; i < burstCount; i++)
        {
            
            Vector2 targetDirection = PlayerController.Instance.transform.position - transform.position;
            SFXManager.Instance.PlayAudio(5);
            animator.SetTrigger("Attack");
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.transform.right = targetDirection;
            yield return new WaitForSeconds(timeBetweenBurst);

        }



        yield return new WaitForSeconds(restTime);
        isShooting = false;

    }
}
