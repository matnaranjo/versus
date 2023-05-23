using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    [SerializeField]
    GameObject textBtn;

    // Go to lobby when button clicked
    public void changeScene(){
        SceneManager.LoadScene("Lobby");
    }
}
