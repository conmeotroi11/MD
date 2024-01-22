using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Quest : MonoBehaviour
{
    [SerializeField] private Button firstQuestButton;
    [SerializeField] private Button secondQuestButton;
    [SerializeField] private TextMeshProUGUI firstQuestButtonText;
    [SerializeField] private TextMeshProUGUI secondQuestButtonText;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject firstQuestPanel;
    [SerializeField] private GameObject secondQuestPanel;
    private bool firstQuest = false;
    private bool secondQuest = false;



    void Update()
    {
        UnlockFirstQuestButton();
        UnlockSecondQuestButton();
        LoadQuest();
        if(firstQuest == true)
        {
            Destroy(firstQuestPanel);
        }
        if(secondQuest == true)
        {
            Destroy(secondQuestPanel);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }

    public void FirstQuest()
    {
        CoinManager.Instance.Coin += 4;
        firstQuest = true;
        SaveQuest();

    }
    public void SecondQuest()
    {
        CoinManager.Instance.Coin += 10;
        secondQuest = true;
        SaveQuest();


    }

    private void UnlockFirstQuestButton()
    {
        if(PlayerCheck.Instance.DefeatEnemy == true)
        {
            firstQuestButton.interactable = true;
            firstQuestButtonText.text = "Completed";
        }
        else
        {
            firstQuestButton.interactable = false;
            firstQuestButtonText.text = "UnCompleted";
        }
    }

    private void UnlockSecondQuestButton()
    {
        if(PlayerCheck.Instance.FirstBossDeath == true )
        {
            secondQuestButton.interactable = true;
            secondQuestButtonText.text = "Completed";
        }
        else
        {
            secondQuestButton.interactable = false;
            secondQuestButtonText.text = "UnCompleted";
        }
    }

    private void SaveQuest()
    {
        PlayerPrefs.SetInt("FirstQuest", firstQuest ? 1 : 0);
        PlayerPrefs.SetInt("SecondQuest", secondQuest ? 1 : 0);
    }
    private void LoadQuest()
    {
        firstQuest = PlayerPrefs.GetInt("FirstQuest", 0) == 1;
        secondQuest = PlayerPrefs.GetInt("SecondQuest",0 ) == 1;
    }

}
