using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplash : MonoBehaviour
{
    Animator bloodSplashAnim;
    bool isPlaying;
    void Start()
    {
        bloodSplashAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        KillBloodSplash();
    }

    void KillBloodSplash(){
        bool isPlaying = bloodSplashAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f;
        if (!isPlaying){
            Destroy(gameObject);
        }
    }
}
