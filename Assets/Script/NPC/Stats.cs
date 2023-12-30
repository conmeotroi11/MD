using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private List<Button> upgradeButton;
    [SerializeField] private List<TextMeshProUGUI> upgradeButtonText;
    [SerializeField] private List<int> price;
    [SerializeField] private List<TextMeshProUGUI> priceText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI speedText;


    private void Update()
    {
        UnlockUpgradeStats();
        StatsInfo();
    }

    
    private void UnlockUpgradeStats()
    {
        for (int i = 0; i < price.Count; i++)
        {
            {
                if (CoinManager.Instance.coin >= price[i])
                {
                    upgradeButton[i].interactable = true;
                    upgradeButtonText[i].text = "Upgrade";
                }
                else if (CoinManager.Instance.coin < price[i])
                {
                    upgradeButton[i].interactable = false;
                    upgradeButtonText[i].text = "Lock";
                }
            }

            priceText[i].text = "Price: "  + price[i].ToString();
        }
    }

    private void StatsInfo()
    {
        hpText.text = "HP: " + PlayerHealth.Instance.MaxHealth.ToString();
        speedText.text = "Speed: " + PlayerController.Instance.MoveSpeed.ToString();
       
    }

    public void UpgradeStats(int statsIndex)
    {
        if(statsIndex == 0)
        {
            if(PlayerHealth.Instance.MaxHealth < 100)
            {
                CoinManager.Instance.coin -= price[statsIndex];
                PlayerHealth.Instance.MaxHealth += 1;
                PlayerHealth.Instance.CurrentHealth = PlayerHealth.Instance.MaxHealth;
                PlayerHealth.Instance.UpdateHealthSlider();
            }

        }
        if(statsIndex == 1)
        {
            if(PlayerController.Instance.MoveSpeed < 25)
            {
                CoinManager.Instance.coin -= price[statsIndex];
                PlayerController.Instance.MoveSpeed += 1;
            }
            
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
}
