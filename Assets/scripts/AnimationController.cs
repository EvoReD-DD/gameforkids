using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject player;
    public GameObject hand1;
    public GameObject hand2;
    private float timecountdown;


    private void Start()
    {
        timecountdown = 2f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

       
        if (collision.gameObject.GetComponent<Zub>())
        {
            AnimPlay();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<Zub>())
        {
           
            AnimPlay();
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        AnimStop();
       
    }


    private void AnimPlay()
    {
        hand1.GetComponent<Animation>().Play("HandZombi");
        hand2.GetComponent<Animation>().Play("Handzombie2");
        
    }

    private void AnimStop()
    {
        hand1.GetComponent<Animation>().Stop("HandZombi");
        hand2.GetComponent<Animation>().Stop("Handzombie2");
        
    }
    private void Counter()
    {

        if (timecountdown <= 0.0f)
        {
            AnimStop();
        }
    }

}