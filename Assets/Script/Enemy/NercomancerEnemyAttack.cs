using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NercomancerEnemyAttack : MonoBehaviour, IEnemyAttack
{
    [SerializeField] private EnemyObjectPooling pooling;
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
            Vector2 targetDirection = PlayerController.Instance.transform.position - transform.position;
            SFXManager.Instance.PlayAudio(5);
            animator.SetTrigger("Attack");
            GameObject newFire = pooling.GetPooledObject();
            newFire.transform.position = transform.position;
            newFire.transform.right = targetDirection;
            newFire.SetActive(true);
            yield return new WaitForSeconds(restTime);
            isShooting = false;

    }
    private IEnumerator RandomShottingRoutine() 
    {
        float randomDelay = Random.Range(1, 3);
        yield return new WaitForSeconds(randomDelay);
        StartCoroutine(ShootRoutine());
    }
}
