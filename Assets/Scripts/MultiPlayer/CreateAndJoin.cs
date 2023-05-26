using UnityEngine.SceneManagement;
using System.Collections;
using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    // Text inputs
    public TextMeshProUGUI createInput;
    public TextMeshProUGUI joinInput;

    // Show and hide "room not available" GameObject
    public GameObject notAvailableRoom;
    private float counterTime=0;

    void FixedUpdate(){

        // if the "room not available" is active, let it be 3 seconds and hide the message
        counterTime +=Time.fixedDeltaTime;
        if (counterTime >= 3 && notAvailableRoom.activeSelf){
            notAvailableRoom.SetActive(false);
        }
    }
    

    public void createRoom(){
        // Create room (max 8 players per room)
        string room = createInput.text;
        string emptySpace = "\u200B";
        string space = " ";

        room = room.Replace(emptySpace,"");
        room = room.Replace(space, "");
        PhotonNetwork.CreateRoom(room,new RoomOptions { MaxPlayers = 8 }, null);
    }

    // If not the room is not created, set active the "room not available" poster
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        counterTime = 0;
        notAvailableRoom.SetActive(true);
    }

    public void joinRoom(){
        // Join Room
        string room = joinInput.text;
        string emptySpace = "\u200B";
        string space = " ";

        room = room.Replace(emptySpace,"");
        room = room.Replace(space, "");
        PhotonNetwork.JoinRoom(room);
    }

    // If not joined room, set active the "room not available" poster
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        counterTime = 0;
        notAvailableRoom.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        // Wait for players (min 4, max 8)
        StartCoroutine(SceneChangeCR());
    }


    IEnumerator SceneChangeCR(){
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("WaitingRoom");
    }
}
