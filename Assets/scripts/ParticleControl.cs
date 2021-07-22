using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem dirt;


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        ParticlePlay(collision);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
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

            dirt.Play();
         
        }
    }

    public void ParticleStop()
    {
        dirt.Stop();
    }
   
}
