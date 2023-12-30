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
        Save.DeleteKey();
        AudioListener.volume = 0f;
        yield return new WaitForSecondsRealtime(10);
        AudioListener.volume = 1f;
        Application.Quit();

    }
    

    
}
