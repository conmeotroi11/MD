using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    private void Start()
    {
        if (PlayerCheck.Instance.SecondBossDeath == true)
        {
           gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

  
}
