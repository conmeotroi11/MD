using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    private Knockback knockback;
    private GetHitFlash getHitFlash;
    [SerializeField] private int maxHealth;
    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    [SerializeField] int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    [SerializeField] private float dameRecoveryTime = 1f;
    [SerializeField] private float knockBackThurst;
    public bool canTakeDame = true;
    private Animator animator;
    private Slider healthSlider;
    [SerializeField] private GameObject weapon;
    public bool isDead;
    [SerializeField] private GameObject deathPanel;


    protected override void Awake()
    {
        base.Awake();
        knockback = GetComponent<Knockback>();
        getHitFlash = GetComponent<GetHitFlash>();
        animator = GetComponent<Animator>();
    }

    
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            TakeDame(1, collision.transform);
        }
    }
    public void TakeDame(int damage, Transform hitTransfrom)
    {
        if (!canTakeDame || isDead) { return; }
        canTakeDame = false;
        ScreenShake.Instance.ShakeScreen();
        currentHealth -= damage; 
        knockback.GetKnockBack(hitTransfrom, knockBackThurst);
        StartCoroutine(getHitFlash.FlashRoutine()); 
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        PlayerDeath();



    }
    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(dameRecoveryTime);
        canTakeDame = true;
    }

    private void PlayerDeath()
    {
        if (currentHealth <= 0 && !isDead)
        {
            Save.SaveData();
            isDead = true;
            animator.SetBool("Death", true);
            canTakeDame = false;
            weapon.SetActive(false);
            PlayerController.Instance.canMove = false;
            StartCoroutine(DeathRoutine());

        }
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(1f);
        UIFade.Instance.FadeToBlack();
        yield return new WaitForSeconds(1f);
        deathPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Death", false);
        currentHealth = maxHealth;
        PlayerController.Instance.transform.position = new Vector3(0, 0, 0);
        canTakeDame = true;
        PlayerController.Instance.canMove = true;
        weapon.SetActive(true);
        UpdateHealthSlider();
        SceneManager.LoadScene("Home");
        isDead = false;
        yield return new WaitForSeconds(0.5f);
        deathPanel.SetActive(false);
        UIFade.Instance.FadeToClear();
    }

    public void UpdateHealthSlider()
    {
        if(healthSlider == null)
        {
            healthSlider = GameObject.Find("Health Slider").GetComponent<Slider>();
        }
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = CurrentHealth;
    }

   
}
