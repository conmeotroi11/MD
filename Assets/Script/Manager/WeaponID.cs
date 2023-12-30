using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponID 
{
    private static int weaponIDs =-1;
    public static int WeaponIDs
    {
        get { return weaponIDs; }
        set { weaponIDs = value; }
    }
}
