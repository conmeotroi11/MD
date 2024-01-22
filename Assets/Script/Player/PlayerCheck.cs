using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : Singleton<PlayerCheck>
{
    private bool firstBossDeath = false;
    private bool secondBossDeath = false;
    private bool defeatEnemy = false;
    public bool FirstBossDeath { get { return firstBossDeath; }}
    public bool SecondBossDeath { get { return secondBossDeath; }}
    public bool DefeatEnemy { get { return defeatEnemy; }}
    private void Start()
    {
        LoadData();
        FirstBossDeathEvent.FirstBossDeath += FirstBossDefeat;
        SecondBossDeathEvent.SecondBossDeath += SecondBossDefeat;
        QuestEvent.DefeatEnemy += DefeatEnemies;
    }

    private void FirstBossDefeat()
    {
        firstBossDeath = true;
        SaveData();
    }
    private void SecondBossDefeat()
    {
        secondBossDeath = true;
        SaveData();
    }

    private void DefeatEnemies()
    {
        defeatEnemy = true;
        SaveData() ;
    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("FirstBossDeath", firstBossDeath ? 1 : 0);
        PlayerPrefs.SetInt("SecondBossDeath", secondBossDeath ? 1 : 0);
        PlayerPrefs.SetInt("DefeatEnemies", defeatEnemy ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        firstBossDeath = PlayerPrefs.GetInt("FirstBossDeath", 0) == 1;
        secondBossDeath = PlayerPrefs.GetInt("SecondBossDeath", 0) == 1;
        defeatEnemy = PlayerPrefs.GetInt("DefeatEnemies", 0) == 1;
    }
}
