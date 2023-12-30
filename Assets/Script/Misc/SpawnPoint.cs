using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
    void Start()
    {
        PlayerController.Instance.transform.position = transform.position;
    }

    
}
