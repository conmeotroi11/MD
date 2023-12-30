using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Staff : Weapon
{

    [SerializeField] private Transform fireSpawnPoint;
    private GameObject weapon;
    [SerializeField] private float staffAttackCooldown;
    private ObjectPooling pooling;
    private Animator animator;



    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        weapon = GameObject.Find("Weapon");
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Start()
    {
        base.Start();
        attackCooldown = staffAttackCooldown;
    }

    protected override void Update()
    {
        base.Update();
        if( pooling == null )
        {
            pooling = FindAnyObjectByType<ObjectPooling>();

        }

    }

    public override void WeaponFlip()
    {
        Vector3 mousePos = Input.mousePosition; 
        Vector3 playerSreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position); 
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (mousePos.x < playerSreenPoint.x)
        {
            weapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public override void Attack()
    {
        if (PlayerController.Instance.IsDasing || !canAttack) { return; }
        SFXManager.Instance.PlayAudio(0);
        animator.SetTrigger("Fire");
        SpawnFire();
        canAttack = false;
    }
    public void SpawnFire() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;  
        Vector3 direction = mousePos - fireSpawnPoint.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject newFire = pooling.GetPooledObject();
        newFire.transform.position = fireSpawnPoint.transform.position;
        newFire.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        newFire.SetActive(true);
    }
}
