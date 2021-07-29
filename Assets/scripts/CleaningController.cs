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
    public float bonus;

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
    void CleanDone()
    {
        particlesBonus.Play();
        bonus = bonus + 1;
        Debug.Log(bonus);
    }
}
