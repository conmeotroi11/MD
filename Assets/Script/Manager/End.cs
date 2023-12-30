using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(10);
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    

    
}
