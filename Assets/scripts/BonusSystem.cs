using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusSystem : MonoBehaviour
{

    [SerializeField] ParticleSystem particlesBonus;
    [SerializeField] GameObject toothController;
    public float bonus;

    public void ParticleBonus()
    {
        particlesBonus.Play();
        bonus = bonus + 1;
        Debug.Log(bonus);
       
    }
}
