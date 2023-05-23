using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class killBuff : MonoBehaviour
{

    float timeToKill =0.0f;

    // Update is called once per frame
    void Update()
    {
        // Kill gameObject every 25 seconds
        if (timeToKill>=28.0f){
            killObject();
        }
        timeToKill += Time.deltaTime;
    }

    void killObject(){
        Destroy(gameObject);
    }

    // if player collides with the buff, call getAmmo if it was a bullet or a health buff.
    void OnTriggerEnter2D(Collider2D col){
        PhotonView view = col.gameObject.GetComponent<PhotonView>();
        PlayerInfo playerInfo = col.gameObject.GetComponent<PlayerInfo>();
        if (view.IsMine){
            if (gameObject.tag == "bullet"){
                playerInfo.getAmmo();
            }
            else{
                playerInfo.getHealth();
            }
            Destroy(gameObject);
        }
    }
}
