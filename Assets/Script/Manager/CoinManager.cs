using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class CoinManager : Singleton<CoinManager>
{
    [SerializeField] private TextMeshProUGUI coinCount;
    public  int coin = 0;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        coinCount.text = coin.ToString();
        Cheat();
    }
    private void Cheat()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            coin += 100;
        }
    }
}
