using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveMouse : MonoBehaviour

{

    public Transform player;


    void OnMouseDrag()
    {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.position = new Vector2(mousePos.x, mousePos.y);
    }

}