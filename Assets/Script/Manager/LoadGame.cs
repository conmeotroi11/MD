using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;
    [SerializeField] private GameObject Weapon;
    [SerializeField] private List<GameObject> weaponPool;
    [SerializeField] private GameObject Pool;
    void Start()
    {
        //Save.LoadData();
        //WeaponLoad();
        Save.DeleteKey();
        


    }

    private void WeaponLoad()
    {
        if (Weapon == null || Pool == null)
        {    
            return;
        }
        for ( int i = 0; i < weapons.Count; i++ )
        {
            if( WeaponID.WeaponIDs == i)
            {
                Destroy(Weapon.transform.GetChild(0).gameObject);
                Instantiate(weapons[i], Weapon.transform);
                Destroy(Pool.transform.GetChild(0).gameObject);
                Instantiate(weaponPool[i], Pool.transform);
            }
        }
    }
}
