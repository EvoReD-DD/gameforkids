using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZubAnimationController : MonoBehaviour
{
    private float t = 60f; 


    [SerializeField] private GameObject pulsezub;
    [SerializeField] private ParticleSystem starParticle;
    [SerializeField] private GameObject zubPlox;

    // Start is called before the first frame update
    void Update()
    {
        //Destroy();
    }
    void OnTriggerStay2D (Collider2D collision)
    {
        
        StartCoroutine(FadeIn());
       
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
       
        StopCoroutine(FadeIn());
    }

    private void AnimStop()
    {
        if (t<=0)
        {
             Debug.Log("ANIMSTOPPED");
             pulsezub.GetComponent<Animation>().Stop();
             pulsezub.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            Destroy();
        }
        
    }
    IEnumerator FadeIn()
    {
        while (t > 0f)
        {
            t -= Time.deltaTime; // отнимаем от t с каждым циклом время после посл. фрейма пока t не станет 0 или меньше. Тут я еще умнажаю на 1.5, тут уже смотрите как вам точнее нужно
            float a = t; 
            zubPlox.GetComponent<Image>().color = new Color(255, 255, 255, a);
            if (t <= 0)
            {
                starParticle.Play();
                AnimStop();
                
            }
            yield return 0;
            
        }
    }
    void Destroy()
    {
            Destroy(pulsezub,2f);
    }
}
