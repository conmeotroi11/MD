using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossDeathEvent : MonoBehaviour
{
    public static event Action SecondBossDeath;
    [SerializeField] private GameObject boss2;


    void Update()
    {
        if (boss2 == null)
        {
            SecondBossDeath?.Invoke();
        }
    }
}
