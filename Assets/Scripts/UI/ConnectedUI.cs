using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ConnectedUI : MonoBehaviour
{

    Image connectionImgComp;
    
    void Start(){
        connectionImgComp = GetComponent<Image>();
    }
    void FixedUpdate(){
        IsConnected();
    }
    
    private void IsConnected(){
        if (PhotonNetwork.IsConnected){
            connectionImgComp.color = Color.green;
        }
        else{
            connectionImgComp.color = Color.red;
        }
    }
}
