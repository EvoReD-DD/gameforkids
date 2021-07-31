using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToothController : MonoBehaviour
{
    [SerializeField] GameObject blinkTooth;
    [SerializeField] GameObject bonusSystem;
    Coroutine FadeIns = null;
    float alphaD;
   


    void OnTriggerEnter2D(Collider2D collision)
    {
            blinkTooth.GetComponent<Animation>().Stop();
            FadeIns = StartCoroutine(FadeIn());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       
        StopCoroutine(FadeIns);
       /* if (alphaD>0)
        {
            alphaD = 1;
        }*/
        
    }
    
    IEnumerator FadeIn()
    {
        float t = 2f;
        float alpha;
        while (t > 0)
        {
            t -= Time.deltaTime;
            alpha = Mathf.Lerp(0f, 1f, t);
            GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            blinkTooth.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            if (alpha <= 0)
            {
                bonusSystem.GetComponent<BonusSystem>().ParticleBonus();
                Destroy();
            }
            yield return 0;
            
        }
        
    }
    void Destroy()
    {
            Destroy(blinkTooth);
    }
    
}
