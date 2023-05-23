using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WinControl : MonoBehaviour
{

    // Change to "Lobby" scene and leave current room
    public void changeToLobby(){
        SceneManager.LoadScene("Lobby");
        PhotonNetwork.LeaveRoom();
    }

    public void changeToWaitingRoom(){
        SceneManager.LoadScene("WaitingRoom");
    }


}
