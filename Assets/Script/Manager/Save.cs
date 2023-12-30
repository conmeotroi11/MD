using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save 
{
     public static void SaveData()
    {
        PlayerPrefs.SetInt("Health", PlayerHealth.Instance.MaxHealth);
        PlayerPrefs.SetFloat("Speed", PlayerController.Instance.MoveSpeed);
        PlayerPrefs.SetInt("Coin", CoinManager.Instance.Coin);
        PlayerPrefs.SetInt("WeaponID", WeaponID.WeaponIDs);
        PlayerPrefs.Save();
    }
    public static void LoadData()
    {
        if (!PlayerPrefs.HasKey("Health") && !PlayerPrefs.HasKey("Speed") && !PlayerPrefs.HasKey("Coin") && !PlayerPrefs.HasKey("WeaponID")) { return; }
        PlayerHealth.Instance.MaxHealth = PlayerPrefs.GetInt("Health");
        PlayerController.Instance.MoveSpeed = PlayerPrefs.GetFloat("Speed");
        CoinManager.Instance.Coin = PlayerPrefs.GetInt("Coin");
        WeaponID.WeaponIDs = PlayerPrefs.GetInt("WeaponID");

    }

    public static void DeteleKey()
    {
        PlayerPrefs.DeleteAll();
        
    }
}
