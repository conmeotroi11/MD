using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerHealth.Instance.CurrentHealth = PlayerHealth.Instance.MaxHealth;
            SFXManager.Instance.PlayAudio(3);
            Destroy(gameObject);
            PlayerHealth.Instance.UpdateHealthSlider();
        }    
    }
}
