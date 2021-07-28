using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZubAnimationController : MonoBehaviour
{
    private float t = 2f;
    Coroutine FadeIns1 = null;
    Coroutine FadeIns2 = null;
    public float bonus;


    [SerializeField] private GameObject pulsezub1;
    [SerializeField] private GameObject pulsezub2;
    [SerializeField] private ParticleSystem starParticle1;
    [SerializeField] private ParticleSystem starParticle2;
    [SerializeField] private ParticleSystem dirt1;
    [SerializeField] private ParticleSystem dirt2;
    [SerializeField] private GameObject zubPlox1;
    [SerializeField] private GameObject zubPlox2;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hand1;
    [SerializeField] private GameObject hand2;

    void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.GetComponent<Zub>())
        {
            ParticleDirt1Play();
            AnimHandPlay();
        }
      /*  else if (collision.GetComponent<Zub2>())
        {
            ParticleDirt2Play();
            AnimHandPlay();
        }*/
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Zub>())
        {
            FadeIns1 = StartCoroutine(FadeIn1());
            pulsezub1.GetComponent<Animation>().Stop();
        }
       /* else if (collision.GetComponent<Zub2>())
        {
            FadeIns2 = StartCoroutine(FadeIn2());
            pulsezub2.GetComponent<Animation>().Stop();
        }*/
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Zub>())
        {
            StopCoroutine(FadeIns1);
            ParticleDirt1Stop();
            AnimHandStop();
        }
     /*   else if (collision.GetComponent<Zub2>())
        {
            StopCoroutine(FadeIns2);
            ParticleDirt1Stop();
            AnimHandStop();
        }*/
        }
    IEnumerator FadeIn1()
    {
        Debug.Log("startcoroutine");
        while (t > 0)
        {
            t -= Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t);
            zubPlox1.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            yield return 0;
            Stop1();
        }
    }

    IEnumerator FadeIn2()
    {
        Debug.Log("startcoroutine");
        while (t > 0)
        {
            t -= Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t);
            zubPlox2.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            yield return 0;
            Stop2();
        }
    }
    void ParticleDirt1Play()
    {
            dirt1.Play();
    }

    void ParticleDirt1Stop()
    {
        dirt1.Stop();
    }

    void ParticleDirt2Play()
    {
        dirt2.Play();
    }

    void ParticleDirt2Stop()
    {
        dirt2.Stop();
    }
    void Stop1()
    {
        if (t <= 0)
        {
            starParticle1.Play();
            
            pulsezub1.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            ParticleDirt1Stop();
            AnimHandStop();
            bonus = +1;
            Destroy1();
        }
        Debug.Log(bonus);
    }

    void Stop2()
    {
        if (t <= 0)
        {
            starParticle1.Play();

            pulsezub2.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            ParticleDirt2Stop();
            AnimHandStop();
            bonus = +1;
            Destroy2();
        }
        Debug.Log(bonus);
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
    void Destroy1()
    {
       Destroy(pulsezub1,1f);
    }
    void Destroy2()
    {
        Destroy(pulsezub2, 1f);
    }
}
