using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerPref;
    [SerializeField]
    GameObject nameDisplay;

    UserName playerName = new UserName();

    void Start(){
        // spanw the player outside of the map
        Vector3 RandPos = new Vector3 (40f,40f,0);
        PhotonNetwork.Instantiate(PlayerPref.name, RandPos, Quaternion.identity);
        PhotonNetwork.Instantiate(nameDisplay.name, RandPos, Quaternion.identity);
    }
}
