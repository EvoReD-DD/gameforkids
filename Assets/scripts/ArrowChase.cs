using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChase : MonoBehaviour
{
    [SerializeField] GameObject PlayerMoveMouse;
    private bool isDragging;
    [SerializeField] private GameObject arrow;

    private void Update()
    {
        Destroy();
    }
    void Destroy()
    { 
        Debug.Log("isDragging");
        isDragging = PlayerMoveMouse.GetComponent<PlayerMoveMouse>().isDragging;
        if (isDragging==true)
        {
            Destroy(arrow);
        }
    }
}