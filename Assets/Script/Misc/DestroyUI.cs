using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUI : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    [SerializeField] private GameObject muisc;
   
    void Update()
    {
        if(Boss == null)
        {
            Destroy(gameObject);
            Destroy(muisc);
        }
    }
}
