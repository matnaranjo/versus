using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Welcome : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI welcomeText;

    [SerializeField]
    GameObject binObject;
    UserName playerName = new UserName();
    void Start()
    {
        // Use the name draged by the Scriptable from intro
        welcomeText.text = playerName.GetName();
    }
}
