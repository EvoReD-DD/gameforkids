using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZubAnimationController : MonoBehaviour
{
    private float t = 30f;


    [SerializeField] private GameObject pulsezub;
    [SerializeField] private ParticleSystem starParticle;
    [SerializeField] private ParticleSystem dirt;
    [SerializeField] private GameObject zubPlox;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hand1;
    [SerializeField] private GameObject hand2;

    void OnTriggerStay2D (Collider2D collision)
    {
        StartCoroutine(FadeIn());
        ParticlePlay();
        AnimHandPlay();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(FadeIn());
        ParticleStop();
        AnimHandStop();
    }
    IEnumerator FadeIn()
    {
        Debug.Log("coroutinestart");
        while (t > 0)
        {
            t -= Time.deltaTime; 
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
    void ParticlePlay()
    {
            dirt.Play();
    }

    void ParticleStop()
    {
        dirt.Stop();
    }
    void AnimStop()
    {
            pulsezub.GetComponent<Animation>().Stop();
            pulsezub.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            ParticleStop();
            AnimHandStop();
            Destroy();
    }
    void AnimHandPlay()
    {
        hand1.GetComponent<Animation>().Play("HandZombi");
        hand2.GetComponent<Animation>().Play("Handzombie2");
    }
    void AnimHandStop()
    {
        hand1.GetComponent<Animation>().Stop("HandZombi");
        hand2.GetComponent<Animation>().Stop("Handzombie2");
    }
    void Destroy()
    {
       Destroy(pulsezub,1f);
    }
}
