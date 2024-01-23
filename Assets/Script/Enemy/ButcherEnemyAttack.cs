using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButcherEnemyAttack : MonoBehaviour , IEnemyAttack
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int burstCount;

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
            StartCoroutine(RandomShottingRoutine());

        }
    }
    private IEnumerator ShootRoutine()
    {
        isShooting = true;
        animator.SetTrigger("Attack");
        for (int i = 0; i < burstCount; i++)
        {
            Vector2 targetDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            SFXManager.Instance.PlayAudio(5);
            float bulletAngle = angle + i * (10f);
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.transform.rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);

            yield return new WaitForSeconds(restTime);
        }

        isShooting = false;
    }

    private IEnumerator RandomShottingRoutine()
    {
        float randomDelay = Random.Range(1, 3);
        yield return new WaitForSeconds(randomDelay);
        StartCoroutine(ShootRoutine());
    }
}
