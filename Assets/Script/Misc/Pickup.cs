using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float pickUpDistance =5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float accelartionRate = 0.2f;

    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    [SerializeField] private Vector3 accelDir;
    private void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 playerpos = PlayerController.Instance.transform.position;
        if(Vector3.Distance(transform.position, playerpos) < pickUpDistance)
        {
            moveDir = (playerpos - transform.position).normalized;
            moveSpeed += accelartionRate;
        }
        else
        {
            moveDir = Vector3.zero;
            moveSpeed = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinManager.Instance.coin++;
            SFXManager.Instance.PlayAudio(4);
            Destroy(gameObject);
        }
    }

    private IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;

        float RandomX = transform.position.x + Random.Range(-2f, 2f);
        float RandomY = transform.position.y + Random.Range(-1f, 1f);

        Vector2 endPoint = new Vector2(RandomX, RandomY);

        float timePassed = 0f;
        while(timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / popDuration;
            float heightT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f,heightY, heightT);
            transform.position = Vector2.Lerp(startPoint, endPoint, linearT) + new Vector2(0f, height); ;
            yield return null;
        }

    }
}
