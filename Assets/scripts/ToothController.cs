using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToothController : MonoBehaviour
{
    [SerializeField] GameObject[] toothPlox;
    [SerializeField] GameObject[] pulseTooth;
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
        ParticleDirtStop();
        AnimHandStop();
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
            if (DestroyColl.GetComponent<Zub>())
            {
                toothPlox[0].GetComponent<Image>().color = new Color(255, 255, 255, alpha);
                pulseTooth[0].GetComponent<Image>().color = new Color(255, 255, 255, 0);
                if (alpha == 0)
                {
                    CleanDone();
                    AnimHandStop();
                    ParticleDirtStop();
                    Destroy();
                }
            }
            else if (DestroyColl.GetComponent<Zub2>())
            {
                toothPlox[1].GetComponent<Image>().color = new Color(255, 255, 255, alpha);
                pulseTooth[1].GetComponent<Image>().color = new Color(255, 255, 255, 0);
                if (alpha == 0)
                {
                    CleanDone();
                    AnimHandStop();
                    ParticleDirtStop();
                    Destroy();
                }
            }
            yield return 0;

        }
    }
    
    void Destroy()
    {
        Destroy(pulseTooth);
    }
}
