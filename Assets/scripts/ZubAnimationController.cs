using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZubAnimationController : MonoBehaviour
{
    private float t = 2f;
    private float alpha;
    Coroutine FadeIns = null;
    Coroutine FadeIns2 = null;

    public float bonus;


    [SerializeField] private GameObject pulsezub2;
    [SerializeField] private GameObject pulsezub1;
    [SerializeField] private ParticleSystem starParticle;
    [SerializeField] private ParticleSystem dirt;
    [SerializeField] private GameObject zubPlox2;
    [SerializeField] private GameObject zubPlox1;
    [SerializeField] private GameObject hand1;
    [SerializeField] private GameObject hand2;
    Collider2D DestroyColl;

    void OnTriggerStay2D(Collider2D collision)
    {
        DestroyColl = collision;
        if (collision.GetComponent<Zub>())
        {
            ParticleDirtPlay();
            AnimHandPlay();
        }
        else
        {
            ParticleDirtPlay();
            AnimHandPlay();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        FadeIns = StartCoroutine(FadeIn());
        if (collision.GetComponent<Zub>())
        {
            zubPlox1.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            pulsezub1.GetComponent<Animation>().Stop();
        }
        else if (collision.GetComponent<Zub2>())
        {
            zubPlox2.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            pulsezub2.GetComponent<Animation>().Stop();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        StopCoroutine(FadeIns);
        StopCoroutine(FadeIns2);
        ParticleDirtStop();
        AnimHandStop();
    }
    IEnumerator FadeIn()
    {
        while (t > 0)
        {
                t -= Time.deltaTime;
                alpha = Mathf.Lerp(0f, 1f, t);
                yield return 0;
                Stop();
        }
    }
    void ParticleDirtPlay()
    {
        dirt.Play();
    }

    void ParticleDirtStop()
    {
        dirt.Stop();
    }


    void Stop()
    {
        if (t <= 0)
        {
            if (DestroyColl.GetComponent<Zub>())
            {
                starParticle.Play();
               // pulsezub1.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                ParticleDirtStop();
                AnimHandStop();
                bonus = +1;
                Destroy();
            }
            else 
            {
                starParticle.Play();
               // pulsezub2.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                ParticleDirtStop();
                AnimHandStop();
                bonus = +1;
                Destroy();
            }
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
    void Destroy()
    {
        if (DestroyColl.GetComponent<Zub>())
        {
            Destroy(pulsezub1);
        }
        else if (DestroyColl.GetComponent<Zub2>())
        {
            Destroy(pulsezub2);
        }
    }
}
