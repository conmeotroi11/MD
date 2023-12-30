using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossDeathEvent : MonoBehaviour
{
    public static event Action FirstBossDeath;
    [SerializeField] private GameObject boss1;  
    

    void Update()
    {
       if(boss1 == null)
        {
            FirstBossDeath?.Invoke();
        }    
    }
}
