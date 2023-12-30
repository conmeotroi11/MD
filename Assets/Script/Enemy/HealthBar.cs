using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth EnemyHealth;
    [SerializeField] private Slider healthSlider;

  

    private void Update()
    {
        UpdateHealthSlider();
    }
    public void UpdateHealthSlider()
    {
       
        healthSlider.maxValue = EnemyHealth.StartHealth;
        healthSlider.value = EnemyHealth.CurrentHealth;
    }
}
