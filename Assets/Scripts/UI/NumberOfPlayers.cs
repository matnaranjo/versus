using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NumberOfPlayers : MonoBehaviour
{
    TextMeshProUGUI PlayersTxt;
    int firstCount=1;
    Color goodGreen = new Color32(18,102,14,255);
    Color goodRed = new Color32(159,0,0,255);

    void Start()
    {
        PlayersTxt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // if the count is diferent from the number of players, change the txt
        if (firstCount != PhotonNetwork.CurrentRoom.PlayerCount){
            CheckNumberPlayers();
            firstCount = PhotonNetwork.CurrentRoom.PlayerCount;
        }
    }

    // Change "players in the room txt" based on the number of players there. 
    void CheckNumberPlayers(){
        int NumPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
        if (NumPlayers>1){
            PlayersTxt.color = goodGreen;
        }
        else {
            PlayersTxt.color = goodRed; 
        }
        PlayersTxt.text = NumPlayers + "/8";
    }
}
