using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HomeGate : MonoBehaviour
{
    private string sceneName;
    [SerializeField] private int scene;

    private float waitToLoadTime = 2f;


    private void Start()
    {
        if (PlayerCheck.Instance.FirstBossDeath == true)
        {
            scene = 5;
            SaveScene();
        }
        if (PlayerCheck.Instance.SecondBossDeath == true)
        {
            scene = 9;
            SaveScene();
        }
        LoadScene();
        sceneName = scene.ToString();
    }
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
    {
        while (waitToLoadTime >= 0f)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
        UIFade.Instance.FadeToClear();
        PlayerController.Instance.canMove = true;

    }

    private void SaveScene()
    {
        PlayerPrefs.SetInt("Gate", scene);
        PlayerPrefs.Save();
    }

    private void LoadScene()
    {
        scene = PlayerPrefs.GetInt("Gate", 1);
    }

}
