using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    UserName playerName = new UserName();
    void Start()
    {
        // Connect to server and synch scenes of players with master
        PhotonNetwork.NickName  = playerName.GetName();
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        // When connected, join to lobby 
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        // When joined, load scene
        SceneManager.LoadScene("lobby");
    }
}
