using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{

    [SerializeField] private float roamChangeDirFloat;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private bool stopMovingWhileAttack = false;
    private bool canAttack = true;
    private bool isChasingPlayer = false;
    private BossAttack bossAttack;
    private enum State
    {
        Roaming,
        Attacking
    }
    private State state;

    private BossPathfinding bossPathfinding;
    private Vector2 roamPostion;
    private float timeRoaming = 0f;

    private void Awake()
    {
        bossAttack = GetComponent<BossAttack>();
        bossPathfinding = GetComponent<BossPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        roamPostion = GetRoamingPosition();
    }
    private void Update()
    {
        MovementStateControl();
    }

    private void MovementStateControl()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                Roaming();
                break;

            case State.Attacking:
                Attacking();
                break;
        }

    }
    private void Roaming()
    {
        timeRoaming += Time.deltaTime;
        bossPathfinding.MoveTo(roamPostion);
        if (timeRoaming > roamChangeDirFloat)
        {
            roamPostion = GetRoamingPosition();
        }
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < attackRange)
        {
            state = State.Attacking;
            isChasingPlayer = true;
        }
    }
    private void Attacking()
    {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) > attackRange)
        {
            state = State.Roaming;
            isChasingPlayer = false;
        }

        if (isChasingPlayer)
        {
            Chasing();
        }

        if (canAttack)
        {
            canAttack = false;
            bossAttack.Attack();


            if (stopMovingWhileAttack)
            {
                bossPathfinding.StopMoving();
                isChasingPlayer = false;
            }
            else
            {
                bossPathfinding.MoveTo(roamPostion);
            }
            StartCoroutine(AttackCooldownRoutine());
        }
    }

    private void Chasing()
    {

        Vector2 playerPosition = PlayerController.Instance.transform.position;
        bossPathfinding.FollowTo(playerPosition);

    }
    private IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }



    private Vector2 GetRoamingPosition()
    {
        timeRoaming = 0f;
        return Random.insideUnitCircle.normalized;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Collider"))
        {
            roamPostion = GetRoamingPosition();
        }
    }
}
