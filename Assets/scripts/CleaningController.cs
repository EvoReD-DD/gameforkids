using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningController : MonoBehaviour
{
    [SerializeField] ParticleSystem particlesDirt;
    
    [SerializeField] GameObject handLeft;
    [SerializeField] GameObject handRight;
    

    void OnTriggerExit2D(Collider2D collision)
    {
        ParticleDirtStop();
        AnimHandStop();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        ParticleDirtPlay();
        AnimHandPlay();
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
    
}
