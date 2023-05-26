using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.Collections;

public class GoToGame : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject PlayGameObject;
    private Button PlayButton;
    void Start(){
        // get the component of the button 
        PlayButton = PlayGameObject.GetComponent<Button>();
        PhotonNetwork.CurrentRoom.IsOpen = true;

        // if the player is the one who created the room, set active the button only for him
        if (PhotonNetwork.LocalPlayer.IsMasterClient){
            PlayGameObject.SetActive(true);
        }
    }
    void FixedUpdate(){
        // if the player is the one who created the room, run the function for him
        if (PhotonNetwork.LocalPlayer.IsMasterClient){
            ActivateButton();
        }
    }
    void ActivateButton(){
        // if players in the room are more than 4 activate the button to start the game
        if (PhotonNetwork.CurrentRoom.PlayerCount>=2){
            PlayButton.interactable=true;
        }
        else {
            PlayButton.interactable=false;
        }
    }
    public void Play(){
        StartCoroutine(PlayCR());
    }

    IEnumerator PlayCR(){
        yield return new WaitForSeconds(0.8f);
        // start the game scene called "Game" and close the room for more people
        PhotonNetwork.LoadLevel("Game");
        PhotonNetwork.CurrentRoom.IsOpen = false;
    }
    
}
