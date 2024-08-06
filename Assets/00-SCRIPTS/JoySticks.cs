using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class JoySticks : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RectTransform outLinetJoyStick;
    [SerializeField] RectTransform knobJoyStick;
    Vector3 clickScreen;
    Vector3 userMoveJoyceStick;
    Vector3 dir;
    [SerializeField] float moveFactor;
    Vector3 move;
    private bool canControl = false;
    void Start()
    {
        HideJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
            ControlJoystick();


    }
    public void ClickOnGUI()
    {
        canControl = true;
        clickScreen = Input.mousePosition;
        outLinetJoyStick.transform.position = clickScreen;
        ShowJoystick();
    }
    public Vector3 GetMoveVector()
    {
        return move ;
    }
    void ControlJoystick()
    {

        userMoveJoyceStick = Input.mousePosition;
        dir = userMoveJoyceStick - clickScreen;


         float moveMagnitude=dir.magnitude*moveFactor/Screen.width;
         moveMagnitude=Math.Min(moveMagnitude,outLinetJoyStick.rect.width/2);
    
        move = dir.normalized *moveMagnitude;


        Vector3 targetPos=clickScreen+move;
       knobJoyStick.transform.position=targetPos;
        if (Input.GetMouseButtonUp(0))
            HideJoystick();
    }
    void HideJoystick()
    {
        outLinetJoyStick.gameObject.SetActive(false);
        canControl = false;

        move = Vector3.zero;
    }
    private void ShowJoystick()
    {
        outLinetJoyStick.gameObject.SetActive(true);
        canControl = true;
    }
}
