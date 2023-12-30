using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private List<Button> buyButton;
    [SerializeField] private List<TextMeshProUGUI> buyButtonText;
    [SerializeField] private List<int> price;
    [SerializeField] private List<TextMeshProUGUI> priceText;
    [SerializeField] private List<GameObject> weapons;
    [SerializeField] private GameObject Weapon;
    [SerializeField] private List<GameObject> weaponPool;
    [SerializeField] private GameObject Pool;



    private void Update()
    {
        UnlockBuyButton();

        if(Pool == null)
        {
            Pool = GameObject.Find("Pool");
        }
        if(Weapon == null)
        {
            Weapon = GameObject.Find("Weapon");
        }
    }
    private void UnlockBuyButton()
    {

        for (int i = 0;i < price.Count; i++) 
        {
            if (CoinManager.Instance.coin >= price[i])
            {
                buyButton[i].interactable = true;
                buyButtonText[i].text = "Buy";
            }
            else if (CoinManager.Instance.coin < price[i])
            {
                buyButton[i].interactable = false;
                buyButtonText[i].text = "Lock";
            }
            priceText[i].text = "Price: " + price[i].ToString();
        }
        
    }

    public void BuyWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weapons.Count)
        {
           
            CoinManager.Instance.coin -= price[weaponIndex];
            Destroy(Weapon.transform.GetChild(0).gameObject);
            Instantiate(weapons[weaponIndex], Weapon.transform);
            Destroy(Pool.transform.GetChild(0).gameObject);
            Instantiate(weaponPool[weaponIndex], Pool.transform);
            WeaponID.WeaponIDs = weaponIndex;

            
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
