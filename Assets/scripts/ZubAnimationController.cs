using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZubAnimationController : MonoBehaviour
{
    private float timeCountDown = 6f;

   
    [SerializeField] private GameObject pulsezub;
    [SerializeField] private ParticleSystem starParticle;
    [SerializeField] private GameObject zubPlox;

    // Start is called before the first frame update
    void Update()
    {
        Debug.Log("Time:" + timeCountDown);
    }
    void OnTriggerStay2D (Collider2D collision)
    {
        
        timeCountDown -= Time.fixedDeltaTime; //сч₴тчик для остановки анимации
        StartCoroutine(FadeIn());
        if (timeCountDown <= 0)
            {
                AnimStop();
        }
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("peremennaya2");
        timeCountDown = 6f; 
    }

    private void AnimStop()
    {
        
        Debug.Log("ANIMSTOPPED");
        pulsezub.GetComponent<Animation>().Stop();
        pulsezub.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        
    }
    IEnumerator FadeIn()
    {
        Debug.Log("startCoroutine");
        float t = 3f; // сначала она 100% не прозрачна, поэтому t = 1

        while (t > 0f)
        {
            t -= Time.fixedDeltaTime; // отнимаем от t с каждым циклом время после посл. фрейма пока t не станет 0 или меньше. Тут я еще умнажаю на 1.5, тут уже смотрите как вам точнее нужно
            float a = t; 
            zubPlox.GetComponent<Image>().color = new Color(255, 255, 255, a);
            if (t <= 0)
            {
                starParticle.Play();
            }// и обновляем прозрачность картинки с помощью "a"
            yield return 0;
            if (t <= 0)
            {
                Destroy(zubPlox);
            }
        }
    }
}
