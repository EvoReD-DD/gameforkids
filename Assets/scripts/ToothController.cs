using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToothController : MonoBehaviour
{
    [SerializeField] GameObject pulseTooth;
    Collider2D DestroyColl;
    Coroutine FadeIns = null;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyColl = collision;
            pulseTooth.GetComponent<Animation>().Stop();
            FadeIns = StartCoroutine(FadeIn());
            ParticleDirtPlay();
            AnimHandPlay();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
       
        StopCoroutine(FadeIns);
    }
    
    IEnumerator FadeIn()
    {
        float t = 2f;
        float alpha;
        while (t > 0)
        {
            t -= Time.deltaTime;
            alpha = Mathf.Lerp(0f, 1f, t);
                this.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
                pulseTooth.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                if (alpha == 0)
                {
                    CleanDone();
                    AnimHandStop();
                    ParticleDirtStop();
                    
                }
            }
            yield return 0;

        }
    }
}
