using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingNPC : MonoBehaviour
{
    public void HealingPlayer()
    {
        PlayerHealth.Instance.CurrentHealth = PlayerHealth.Instance.MaxHealth;
        SFXManager.Instance.PlayAudio(3);
        PlayerHealth.Instance.UpdateHealthSlider();
    }
}
