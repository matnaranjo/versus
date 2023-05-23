using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour
{

    [SerializeField]
    Sprite[] blood;
    public void screenChange(int health){
        if (health>=0){
            Image imageController = gameObject.GetComponent<Image>();
            imageController.sprite = blood[health];
        }
    }
}
