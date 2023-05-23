using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;
    GameObject nameDisplay; //nameDisplay that will follow the player above its head
    JoystickInfo joyStick;
    PhotonView view;
    Vector3 MousePos;
    Vector3[] positions = {new Vector3(-30f,30f,0f), new Vector3(30f,-30f,0f), new Vector3(-30f,-30f,0f), new Vector3(30f,30f,0f)};



    void Start(){
        view = GetComponent<PhotonView>();


        if (view.IsMine){
            // Spawn player anywhere in the map
            transform.position = new Vector3(Random.Range(-31, 31), Random.Range(-31, 31),0f );

            joyStick = GameObject.FindGameObjectWithTag("joystick").GetComponent<JoystickInfo>();
            nameDisplay = GameObject.FindGameObjectWithTag("namedisplay"); //Get the object if the view is mine
            nameDisplay.transform.position = transform.position + new Vector3(0,0.7f,0);
        }
    }
    void FixedUpdate()
    {
        if (view.IsMine){
            MobilePlayerMovement();
        }
    }

    void PlayerMovement(){

        #region rotation
        // 1 - Get mouse position
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = 0;
        // 2 - Mouse position - Player pos to get X and Y magnitud between them
        Vector3 relative = MousePos - transform.position;
        // 3 - Atan (Y/X) = Angle
        float angle = Mathf.Atan2(relative.y, relative.x)* Mathf.Rad2Deg;
        // 4 - Change angle o the player
        transform.eulerAngles = new Vector3(0, 0, angle);
        #endregion

        #region movement
        // Get axis for direction
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        // Move the character
        Vector3 posChange = new Vector3 (Horizontal, Vertical,0) * speed * Time.fixedDeltaTime;
        transform.position += posChange;
        #endregion
    }

    void MobilePlayerMovement(){
        # region rotation
        float angle = joyStick.AngleInfo();
        transform.eulerAngles = new Vector3(0, 0, angle);
        #endregion

        # region movement
        Vector3 dir = joyStick.ComponentInfo();
        Vector3 posChange = dir * speed * Time.fixedDeltaTime;
        transform.position +=posChange;
        nameDisplay.transform.position = transform.position + new Vector3(0,0.7f,0); // move the display to the same places the player goes
        #endregion
    }


}
