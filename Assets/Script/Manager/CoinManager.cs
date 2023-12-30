using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class CoinManager : Singleton<CoinManager>
{
    [SerializeField] private TextMeshProUGUI coinCount;
    private  int coin = 0;
    public int Coin 
    { 
        get { return coin; } 
        set { coin = value; }
    }

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
