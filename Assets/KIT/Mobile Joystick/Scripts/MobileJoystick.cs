using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoystick : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickKnob;

    [Header(" Settings ")]
    [SerializeField] private float moveFactor;
    private Vector3 clickedPosition;
    private Vector3 move;
    private bool canControl;

    // Start is called before the first frame update
    void Start()
    {
        HideJoystick();
    }

    private void OnDisable()
    {
        HideJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if(canControl)
            ControlJoystick();
    }
    
    public void ClickedOnJoystickZoneCallback()
    {
        clickedPosition = Input.mousePosition;
        joystickOutline.position = clickedPosition;

        ShowJoystick();
    }

    private void ShowJoystick()
    {
        joystickOutline.gameObject.SetActive(true);
        canControl = true;
    }

    private void HideJoystick()
    {
        joystickOutline.gameObject.SetActive(false);
        canControl = false;

        move = Vector3.zero;
    }

    private void ControlJoystick()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - clickedPosition;

        //dùng để điều chỉnh chuyển động của joystick dựa trên tỷ lệ này.
        float canvasScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.x;

        //một hệ số moveFactor (có thể là tham số có thể cấu hình), và tỷ lệ scale của Canvas.
        float moveMagnitude = direction.magnitude * moveFactor * canvasScale;


        //Tính toán một nửa chiều rộng của vùng bao quanh joystick.
        float absoluteWidth = joystickOutline.rect.width / 2;
        
        // Điều chỉnh chiều rộng thực của vùng bao quanh joystick dựa trên tỷ lệ scale của Canvas.
        float realWidth = absoluteWidth * canvasScale;

        //Đảm bảo rằng độ lớn chuyển động không vượt quá chiều rộng thực của vùng bao quanh joystick.
        moveMagnitude = Mathf.Min(moveMagnitude, realWidth);

        move = direction.normalized * moveMagnitude;
        
        Vector3 targetPosition = clickedPosition + move;

        joystickKnob.position = targetPosition;

        if (Input.GetMouseButtonUp(0))
            HideJoystick();
    }

    public Vector3 GetMoveVector()
    {
        float canvasScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.x;
        return move / canvasScale;
    }
}
