using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NameDisplay : MonoBehaviour
{

    PhotonView nameView;
    UserName playerName = new UserName();
    TextMeshPro nameText;


    // Start is called before the first frame update
    void Start()
    {
        //If view is mine show my name in the display
        nameView = GetComponent<PhotonView>();
        nameText = GetComponent<TextMeshPro>();
        if (nameView.IsMine){
            nameText.text = playerName.GetName();
        }
        UpdateText();
    }
    private void UpdateText(){
        nameText.text = nameView.Owner.NickName;
    }
}
