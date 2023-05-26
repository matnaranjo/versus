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
        StartCoroutine(change());
    }

    IEnumerator change(){
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Lobby");
    }
}
