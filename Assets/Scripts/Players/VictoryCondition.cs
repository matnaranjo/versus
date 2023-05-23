using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    float checkTime = 0;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkTime+=Time.fixedDeltaTime;

        if (checkTime>=1.0f && view.IsMine){
            checkPlayers();
            checkTime=0.0f;
        }
    }

    // As players get kicked out of the room when they die, keep a count on the number of players and once there is only one, go to win scene
    void checkPlayers(){
        int remaining = PhotonNetwork.PlayerList.Length;

        if (remaining==1){
            SceneManager.LoadScene("Win");
        }
    }

}
