using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] private Image fadeScreen; //tạo biến image fade
    private float fadeSpeed =1f; //tạo thời gian fade

    private IEnumerator fadeRoutine; // tạo 1 vòng lặp faderoutine không có giá trị
    
    public void FadeToBlack() //hàm void fadetoblack để chuyển cảnh làm mờ screen
    {
        if( fadeRoutine != null ) //nếu vòng lặp faderotune có tồn tại
        {
            StopCoroutine(fadeRoutine); //không chạy vòng lặp
        }
        fadeRoutine = FadeRoutine(1); //vòng lặp faderoutine sẽ bằng vòng lặp FadeRoutine(thông số 1)
        StartCoroutine(fadeRoutine); //chạy vòng lặp 
    }

    public void FadeToClear() // tương tự hàm void fadetoblack nhưng là khôi phục lại mặc định
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = FadeRoutine(0);
        StartCoroutine(fadeRoutine);
    }

    private IEnumerator FadeRoutine(float targetAlpha) //vòng lặp để làm mờ screen
    {
        while (!Mathf.Approximately(fadeScreen.color.a, targetAlpha)) //vòng lặp while công thức để làm mờ 
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime); //tương tự
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha); //tương tự
            yield return null; //không cần đợi thời gian vòng lặp
        }
      
    }
}
