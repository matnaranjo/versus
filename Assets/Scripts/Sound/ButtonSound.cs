using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    AudioClip clickSound;
    [SerializeField]
    GameObject bGMusic;

    AudioSource buttonAudioSource;
    void Start(){
        buttonAudioSource=GetComponent<AudioSource>();
    }
    public void Click(){
        buttonAudioSource.PlayOneShot(clickSound);
    }
}
