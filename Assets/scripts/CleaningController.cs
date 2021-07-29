using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningController : MonoBehaviour
{
    [SerializeField] ParticleSystem particlesDirt;
    [SerializeField] ParticleSystem particlesBonus;
    [SerializeField] GameObject handLeft;
    [SerializeField] GameObject handRight;
    [SerializeField] GameObject[] toothPlox;
    [SerializeField] GameObject[] pulseTooth;
    Collider2D DestroyColl;
    Coroutine FadeIns = null;
    public float bonus;

    void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyColl = collision;
        if (collision.GetComponent<Zub>())
        {
            // FadeIns = StartCoroutine(FadeIn());
            pulseTooth[0].GetComponent<Animation>().Stop();
            FadeIns = StartCoroutine(FadeIn());
            ParticleDirtPlay();
            AnimHandPlay();
        }
        else if (collision.GetComponent<Zub2>())
        {
            // FadeIns = StartCoroutine(FadeIn());
            pulseTooth[1].GetComponent<Animation>().Stop();
            FadeIns = StartCoroutine(FadeIn());
            ParticleDirtPlay();
            AnimHandPlay();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        ParticleDirtStop();
        AnimHandStop();
        StopCoroutine(FadeIns);
    }

    void AnimHandPlay()
    {
        handLeft.GetComponent<Animation>().Play("HandZombi");
        handRight.GetComponent<Animation>().Play("Handzombie2");
    }
    void AnimHandStop()
    {
        handLeft.GetComponent<Animation>().Stop("HandZombi");
        handRight.GetComponent<Animation>().Stop("Handzombie2");
    }
    void ParticleDirtPlay()
    {
        particlesDirt.Play();
    }

    void ParticleDirtStop()
    {
        particlesDirt.Stop();
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
    void CleanDone()
    {
        particlesBonus.Play();
        bonus = bonus+1;
        Debug.Log(bonus);
    }
    void Destroy()
    {
        if (DestroyColl.GetComponent<Zub>())
        {
            Destroy(pulseTooth[0]);
        }
        else if (DestroyColl.GetComponent<Zub2>())
        {
            Destroy(pulseTooth[1]);
        }
    }
}
