using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] private string sceneName;


    private float waitToLoadTime = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Save.SaveData();
            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
            PlayerController.Instance.canMove = false;
            SFXManager.Instance.PlayAudio(8);


        }
    }


    private IEnumerator LoadSceneRoutine()
    {  while(waitToLoadTime >= 0f) 
        {
            waitToLoadTime -= Time.deltaTime; 
            yield return null; 
        }
        SceneManager.LoadScene(sceneName);
        UIFade.Instance.FadeToClear();
        PlayerController.Instance.canMove = true;

    }
}
