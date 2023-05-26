using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WinControl : MonoBehaviour
{

    // Change to "Lobby" scene and leave current room
    public void changeToLobby(){
        StartCoroutine(change());
    }

    public void changeToWaitingRoom(){
        SceneManager.LoadScene("WaitingRoom");
    }

    IEnumerator change(){
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Lobby");
        PhotonNetwork.LeaveRoom();
    }


}
