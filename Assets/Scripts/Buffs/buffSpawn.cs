using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class buffSpawn : MonoBehaviour
{
    PhotonView view;
    PlayerInfo player;
    float spawnTime=15.0f;

    [SerializeField]
    GameObject[]Buffs = new GameObject[2];

    Vector3[] buffPositions = {new Vector3(-17f,-30f,0f), new Vector3(4.5f,-26f,0f), new Vector3(18f,-27f,0f),new Vector3(17f,-13f,0f), new Vector3(8.5f,-8.5f,0f),new Vector3(25.5f,-9.5f,0),new Vector3(-9f,-18f,0),new Vector3(-30f,-17f,0f),new Vector3(-17.5f,-4f,0f),new Vector3(8f,-0.5f,0f),new Vector3(26.5f,0.5f,0f),new Vector3(27f,8.5f,0f),new Vector3(5f,8f,0f),new Vector3(-17f,8f,0f),new Vector3(-30f,17.5f,0f),new Vector3(3.5f,20.5f,0f),new Vector3(22f,25f,0f),new Vector3(2f,30f,0f),new Vector3(-17.5f,22f,0f),new Vector3(-1f,-9f,0f)};


    void Start()
    {
        view = GetComponent<PhotonView>();
        player = GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime>=30f){    
            if (view.IsMine){
                buffsOnPosition();
            }
        }
        spawnTime += Time.deltaTime;
    }

    void buffsOnPosition(){
        // Show 5 random buffs in "random" positions every spawnTime 30seg
        int buffIndex = Random.Range(0,4);
        while (buffIndex<20){
            int buffObjectIndex = Random.Range(0,2);
            Instantiate(Buffs[buffObjectIndex], buffPositions[buffIndex], Quaternion.identity);
            buffIndex+=4;
        }
        spawnTime=0.0f;
    }

    
}
