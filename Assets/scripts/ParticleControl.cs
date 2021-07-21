using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem particle;
    private float timeCountDown;


    private void Start()
    {
        timeCountDown = 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        ParticlePlay(collision);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        timeCountDown -= Time.deltaTime;
        Debug.Log(timeCountDown);
        
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

            particle.Play();
         
        }
    }

    public void ParticleStop()
    {
        particle.Stop();
    }
    private void Counter()
    {

        if (timeCountDown <= 0.0f)
        {
            Debug.Log("Done" + timeCountDown);
            ParticleStop();
        }
    }
}
