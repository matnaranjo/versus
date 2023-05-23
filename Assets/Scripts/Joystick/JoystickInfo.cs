using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class JoystickInfo : MonoBehaviour,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // NOTE: center to border of the joystick 60 units
    [SerializeField]
    GameObject stick;
    [SerializeField]
    TextMeshProUGUI test;
    float xComponent = 0;
    float yComponent = 0;
    float angle=0;
    int touchID;
    bool isTouched;


    // The problem where the multiple touch inputs interfere between each other was solved using the interfaces IPointerDownHandler, IPointerUpHandler, IDragHandler. the single ID they provide for each pointer, prevents the signals to mix.

    #region touch input
    public void OnPointerDown(PointerEventData eventData)
    {
        // If the UI element is not touched, I save the id of tha touch event, let the stick activate, and set isTouched to true
        if(!isTouched){
            touchID = eventData.pointerId;
            isTouched = true;
            stick.SetActive(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // While the UI pinter is still active and being draged, the stick has to move along with the finger in the screen
        if (eventData.pointerId == touchID){
            Vector3 touchPos = new Vector3(eventData.position.x, eventData.position.y, 0); //get the position of the finger in the screen
            Vector3 mouseToJoyStick = touchPos - transform.position; // the distance in X and Y between the finger and the center of the joystick UI element
            float mToJSMagnitude = mouseToJoyStick.magnitude; // magnitude of that distance
            angle = Mathf.Atan2(mouseToJoyStick.y, mouseToJoyStick.x)* Mathf.Rad2Deg; // angle between finger and center of UI element
            // Components for player movement
            xComponent = Mathf.Cos(angle*Mathf.Deg2Rad);
            yComponent = Mathf.Sin(angle*Mathf.Deg2Rad);

            //Condition to drag the stick just until the edge of the joystick UI element
            if (mToJSMagnitude < 60){
                stick.transform.position = Input.mousePosition;
            }
            else{
                stick.transform.position = transform.position + new Vector3 (xComponent*60, yComponent*60,0);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {   
        //If the UI element is not being touched, set components to 0 to avoid player movement and center stick and hide it, isTouched to false.
        if (eventData.pointerId == touchID){
            xComponent =0;
            yComponent =0;
            stick.transform.position = transform.position;
            isTouched=false;
            stick.SetActive(false);
        }
    }
    #endregion

    #region info for player
    public Vector3 ComponentInfo(){
        //info for movement
        return new Vector3(xComponent, yComponent,0);
    }
    public float AngleInfo(){
        //info for rotation
        return angle;
    }
    #endregion
}
