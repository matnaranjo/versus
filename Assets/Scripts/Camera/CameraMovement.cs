using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraMovement : MonoBehaviour
{

    PhotonView view;
    float smoothSpeed = 2.0f;

    void Start(){
        // Get player instantiated character view
        view = GetComponent<PhotonView>();

        if (view.IsMine){
            Camera.main.transform.position = gameObject.transform.position;
        }
    }

    void FixedUpdate()
    {
        // if that character view is mine move the camera along the character
        if (view.IsMine){
            cameraMov();
        }
        
    }

    void cameraMov(){
        // move the camera following the character with a little delay
        Vector3 cameraFollow  = gameObject.transform.position;
        cameraFollow.z = -10;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraFollow, smoothSpeed*Time.fixedDeltaTime);
    }
}
