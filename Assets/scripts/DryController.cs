using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryController : MonoBehaviour
{
    [SerializeField] GameObject particlesDirt;
    [SerializeField] GameObject particlesBonus;
    [SerializeField] GameObject handLeft;
    [SerializeField] GameObject handRight;
    [SerializeField] GameObject pulsezub1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Zub>())
        {
            pulsezub1.GetComponent<Animation>().Stop();
            Debug.Log("StopAnimation");
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Zub>())
        {
            
            AnimHandPlay();
        }
    }
    void AnimHandPlay()
    {
        handLeft.GetComponent<Animation>().Play("HandZombi");
        handRight.GetComponent<Animation>().Play("Handzombie2");
    }
}
