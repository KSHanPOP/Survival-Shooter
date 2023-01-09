using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string movevAxisName = "Vertical"; 
    public string moveHAxisName = "Horizontal";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public float moveV { get; private set; } 
    public float moveH { get; private set; } 
    public bool fire { get; private set; } 
    public bool reload { get; private set; } 
    public Vector3 mousePos { get; private set; }

    void Update()
    {
        moveV = Input.GetAxis(movevAxisName);
        moveH = Input.GetAxis(moveHAxisName);
        fire = Input.GetButton(fireButtonName);
        //reload = Input.GetButtonDown(reloadButtonName);

        mousePos = Input.mousePosition;
    }
}