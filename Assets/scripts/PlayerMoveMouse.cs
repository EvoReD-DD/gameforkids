using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveMouse : MonoBehaviour

{
    public bool isDragging;
    public Transform player;

    
    void OnMouseDown()
    {
        isDragging = true;
       
    }
    void OnMouseUp()
    {
        isDragging = false;
    }
    void Update()
    {
        Dragging();
    }
    void Dragging()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.position = new Vector2(mousePos.x, mousePos.y);
        }
    }
}