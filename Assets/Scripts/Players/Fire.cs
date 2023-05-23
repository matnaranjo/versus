using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Fire : MonoBehaviour
{

    PhotonView View;
    PlayerInfo playerInformation;
    AudioSource shotSound;
    Vector3 CannonPos = new Vector3(0.5f,0.4f, 0.0f);
    RaycastHit2D hit;
    [SerializeField]
    GameObject bloodSplash;

    BulletButton bullButton;

    void Start()
    {
        // Get audioSource from gameObject
        shotSound = GetComponent<AudioSource>();
        // Get view from gameObject
        View = GetComponent<PhotonView>();

        // Get Player info component 
        playerInformation = GetComponent<PlayerInfo>();

        bullButton = GameObject.FindGameObjectWithTag("bulletbutton").GetComponent<BulletButton>();
    }

    // Update is called once per frame
    void Update()
    {
        // if order mine, instantiate bullet
        if (View.IsMine){
            Shoot();
        }
    }

    void Shoot (){
        int bullets = playerInformation.ammo;
        if (bullets>0){
            if (bullButton.shoot){
                // Making sure the player only shoots once when pressing down the button, here I'm going to make the bool false
                // So the player has to press again to shoot
                bullButton.shoot = false;

                // Position and rotationof player
                float rotation = transform.eulerAngles.z;
                Vector3 BulletPos = transform.position;
                
                // Origin Point of ray and direction.
                BulletPos += new Vector3(Mathf.Cos((rotation-22.61986495f)*Mathf.Deg2Rad) * 0.65f, Mathf.Sin((rotation-22.61986495f)*Mathf.Deg2Rad) * 0.65f, 0);
                Vector2 rayOrigin = BulletPos;
                Vector2 dir = new Vector2(Mathf.Cos(rotation*Mathf.Deg2Rad), Mathf.Sin(rotation*Mathf.Deg2Rad));

                // Shoot ray and play machinegun sound
                hit = Physics2D.Raycast(rayOrigin,dir,7f);
                shotSound.Play();
                View.RPC("playSoundForOthers", RpcTarget.Others);

                // if there's a collider touching the ray, ask if it is a player, if it is, and the view is my view, call the function "IGotShoot" of the player touched to decrease health
                if (hit.collider!=null){
                    if (hit.collider.gameObject.tag == "Player"){
                        if (View.IsMine){
                            Instantiate(bloodSplash, hit.point, Quaternion.identity);
                            PhotonView hitTarget =  hit.collider.gameObject.GetComponent<PhotonView>();
                            hitTarget.RPC("IGotShoot", RpcTarget.All, hitTarget.ViewID);
                        }
                    }
                }
                playerInformation.lessAmmo();
            }
        }

        
    
    }

    // Play sound for everyone.
    [PunRPC]
    public void playSoundForOthers(){
        shotSound.Play();
    }
}
