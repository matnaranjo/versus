using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Laser : MonoBehaviour
{
    [SerializeField]
    GameObject laserInst;
    GameObject laser;
    PhotonView playerView;
    RaycastHit2D hit;

    float rotation;
    Vector3 laserPos;
    float laserLenght;
    Vector3 laserScale;

    // Start is called before the first frame update
    void Start()
    {   
        playerView = GetComponent<PhotonView>();
        // laser is instantiated inside the player and assigned to laser variable.
        if (playerView.IsMine){
            Instantiate(laserInst,transform.position, transform.rotation);
            laser = GameObject.FindGameObjectWithTag("laser");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerView.IsMine){
            laserMovement();
        }
    }

    void laserMovement(){
        // Position and rotationof player
        rotation = transform.eulerAngles.z;
        laserPos = transform.position;


        // Origin Point of ray and direction.
        laserPos += new Vector3(Mathf.Cos((rotation-22.61986495f)*Mathf.Deg2Rad) * 0.65f, Mathf.Sin((rotation-22.61986495f)*Mathf.Deg2Rad) * 0.65f, 0);
        Vector2 rayOrigin = laserPos;
        Vector2 dir = new Vector2(Mathf.Cos(rotation*Mathf.Deg2Rad), Mathf.Sin(rotation*Mathf.Deg2Rad));

        hit = Physics2D.Raycast(rayOrigin,dir,7f);

        if (hit.collider!=null){
            laserLenght = (new Vector3(hit.point.x, hit.point.y,0)-laserPos).magnitude;
            laserScale = laser.transform.localScale;
            laserScale.x = laserLenght*25.0f;
            laser.transform.localScale = laserScale;
        }
        else{
            laserScale = laser.transform.localScale;
            laserScale.x = 25.0f*7f;
            laser.transform.localScale = laserScale;
        }

        laser.transform.position = laserPos;
        laser.transform.eulerAngles = new Vector3(0,0,rotation);
    }
}
