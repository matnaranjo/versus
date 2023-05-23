using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviourPunCallbacks
{
    public int ammo;
    public int health;
    int healthForChange = 0;

    private GameObject healthObject;
    private GameObject ammoObject;
    private GameObject screenController;

    private TextMeshProUGUI healthText;
    private TextMeshProUGUI ammoText;

    private Effects bloodEffect;

    private PhotonView view;

    void Start(){
        // Find the txt objects
        healthObject = GameObject.FindGameObjectWithTag("healttxt");
        ammoObject = GameObject.FindGameObjectWithTag("ammotxt");
        // Get TMP components of the game objects
        healthText = healthObject.GetComponent<TextMeshProUGUI>();
        ammoText = ammoObject.GetComponent<TextMeshProUGUI>();


        view = gameObject.GetComponent<PhotonView>();
        // Set ammo and health to starting values.
        ammo = 100;
        health = 5;

        screenController = GameObject.FindGameObjectWithTag("blood");
        bloodEffect = screenController.GetComponent<Effects>();
    }

    void FixedUpdate(){
        if (view.IsMine){
            changeTxt();

            if (healthForChange!=health){
                bloodEffect.screenChange(health-1);
                healthForChange=health;
            }
        }
    }
    void Update(){
        if (view.IsMine){
            death();  
        }
    }

    // Change text from UI based on the variables
    void changeTxt(){
        healthText.text = "x " + health.ToString();
        ammoText.text = "x " + ammo.ToString();
    }

    // decrease ammo every shoot
    public void lessAmmo(){
        ammo--;
    }

    // Decrease health when shot (callable from other players)
    [PunRPC]
    public void IGotShoot(int viewID)
    {
        if(view.ViewID == viewID && health>0){
            health -=1;
        }
    }

    // public function used by the buffs hearths to increase health until max of 5
    public void getHealth(){
        if (health+2<=5){
            health+=2;
        }
        else{
            health=5;
        }
    }

    // public function used by the buffs bullets to increase ammo until max of 100
    public void getAmmo(){
        if (ammo+15<=100){
            ammo+=15;
        }
        else{
            ammo=100;
        }
    }

    // if health is 0 change scene to lose and leave the current room.
    public void death(){
        if(health==0){
            SceneManager.LoadScene("Lose");
            // Remember,  LoadBalancingClient.cs has the line 2573 as a comment XD.
            PhotonNetwork.LeaveRoom();
        }
    }

}
