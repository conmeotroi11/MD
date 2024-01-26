using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IEnemyAttack
{
 
    [SerializeField] private int burstCount;
    [SerializeField] private EnemyObjectPooling pooling;
    [SerializeField] private float restTime;
    [SerializeField] private bool isShooting = false;
    private Animator animator;

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
    public IEnumerator ShootRoutine()
    {
        isShooting = true;
        for (int i = 0; i < burstCount; i++)
        {
            
            Vector2 targetDirection = PlayerController.Instance.transform.position - transform.position;
            SFXManager.Instance.PlayAudio(5);
            animator.SetTrigger("Attack");
            GameObject newFire = pooling.GetPooledObject();
            newFire.transform.position = transform.position;
            newFire.transform.right = targetDirection;
            newFire.SetActive(true);
            yield return new WaitForSeconds(restTime);


        }

        isShooting = false;

    }
    public IEnumerator RandomShottingRoutine() 
    {

       float randomDelay = Random.Range(1, 3);
       yield return new WaitForSeconds(randomDelay);
       StartCoroutine(ShootRoutine());
        
    }

  
}
