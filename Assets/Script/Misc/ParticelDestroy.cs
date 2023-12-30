using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticelDestroy : MonoBehaviour
{
    private ParticleSystem ps; 
    void Awake()
    {
        ps = GetComponent<ParticleSystem>(); 
    }


    void Update()
    {
        if (ps && !ps.IsAlive()) 
        {
            Destroy(gameObject); 
        }

    }
}
