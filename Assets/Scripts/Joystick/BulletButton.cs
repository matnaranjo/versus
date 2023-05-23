using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BulletButton : MonoBehaviour, IPointerDownHandler
{
    public bool shoot;
    // The only thing I need to do here is send a message "shoot" to the player's script "fire", it will shoot and change the bool back to false
    public void OnPointerDown(PointerEventData eventData){
        shoot = true;
    }
}
