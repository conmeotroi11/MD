using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButcherEnemyAttack : MonoBehaviour , IEnemyAttack
{
    [SerializeField] private int burstCount;
    [SerializeField] private float restTime;
    private bool isShooting = false;
    private Animator animator;
    [SerializeField] private EnemyObjectPooling pooling;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnDisable()
    {

        StopAllCoroutines();

    }

    private void OnEnable()
    {
        isShooting = false;
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
        SFXManager.Instance.PlayAudio(5);
        for (int i = 0; i < burstCount; i++)
        {
            Vector2 targetDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            float bulletAngle = angle + i * (10f);
            GameObject newFire = pooling.GetPooledObject();
            newFire.transform.position = transform.position;
            newFire.transform.rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);
            newFire.SetActive(true);
            yield return new WaitForSeconds(restTime);
            
        }

        isShooting = false;
    }

    private IEnumerator RandomShottingRoutine()
    {
        float randomDelay = Random.Range(1, 3);
        yield return new WaitForSeconds(randomDelay);
        yield return StartCoroutine(ShootRoutine());
    }
}
