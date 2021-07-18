using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem particle;
    private float timecountdown;


    private void Start()
    {
        timecountdown = 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        ParticlePlay(collision);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        timecountdown -= Time.fixedDeltaTime;
        Debug.Log(timecountdown);
        
        ParticlePlay(collision);


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        ParticleStop();
    }


    public void ParticlePlay(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zub>())
        {
            ParticleSystem particle = GetComponent<ParticleSystem>();
            particle.Play();
         
        }
    }

    public void ParticleStop()
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }
    private void Counter()
    {

        if (timecountdown <= 0.0f)
        {
            Debug.Log("Done" + timecountdown);
            ParticleStop();
        }
    }
}
