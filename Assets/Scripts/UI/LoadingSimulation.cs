using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSimulation : MonoBehaviour
{
    float rotation=0;

    void Start(){
        rotation = transform.rotation.eulerAngles.z;
    }

    void FixedUpdate(){
        rotating();
    }

    // Loading animation of the little ball
    void rotating(){
        rotation-=5;
        transform.localRotation = Quaternion.Euler(0,0,rotation);
    }
}
