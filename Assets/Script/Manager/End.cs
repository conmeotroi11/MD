using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
  
    void Start()
    {
        
        StartCoroutine(ResetRoutine());
    }


    private IEnumerator ResetRoutine()
    {
        Save.DeteleKey();
        yield return new WaitForSecondsRealtime(10);
        Application.Quit();

    }
    

    
}
