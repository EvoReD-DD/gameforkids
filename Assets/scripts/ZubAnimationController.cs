using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZubAnimationController : MonoBehaviour
{
    private float timeCountDown = 2f;


    [SerializeField] private GameObject colorAnimation;
    [SerializeField] private ParticleSystem starParticle;

    // Start is called before the first frame update
   
    void OnTriggerStay2D (Collider2D collision)
    {
            timeCountDown -= Time.deltaTime; //сч₴тчик для остановки анимации

            if (timeCountDown <= 0)
            {
                AnimStop();
            } 
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        timeCountDown = 2f; //ето попытка сбросить переменную при выходе из тригера(но не работает)
    }

    private void AnimStop()
    {
        Debug.Log("ANIMSTOPPED");
        colorAnimation.GetComponent<Animation>().Stop("zubcolor");
        colorAnimation.GetComponent<Image>().color = new Color32(255, 255, 225, 0);

    }

}
