using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToothController : MonoBehaviour
{
    [SerializeField] GameObject pulseTooth;
    Collider2D DestroyColl;
    Coroutine FadeIns = null;
    float alphaD;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
            pulseTooth.GetComponent<Animation>().Stop();
            FadeIns = StartCoroutine(FadeIn());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       
        StopCoroutine(FadeIns);
    }
    
    IEnumerator FadeIn()
    {
        float t = 20f;
        float alpha;
        while (t > 0)
        {
            t -= Time.deltaTime;
            alpha = Mathf.Lerp(0f, 1f, t);
            GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            pulseTooth.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            Destroy();            }
            yield return 0;

        }
    void Destroy()
    {
        if (alphaD == 0)
        {
            Destroy(this);
        }
    }
}
