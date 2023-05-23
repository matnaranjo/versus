using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegLog : MonoBehaviour
{
    [SerializeField]
    GameObject Select;
    [SerializeField]
    GameObject SignUI;
    [SerializeField]
    GameObject LogUI;

    public void activateUI(string UI){

        switch (UI)
        {   
            case "select":
                Select.SetActive(true);
                SignUI.SetActive(false);
                LogUI.SetActive(false);
                break;
            
            case "sign":
                Select.SetActive(false);
                SignUI.SetActive(true);
                LogUI.SetActive(false);
                break;
            
            case "log":
                Select.SetActive(false);
                SignUI.SetActive(false);
                LogUI.SetActive(true);
                break;

            default:
                Select.SetActive(true);
                SignUI.SetActive(false);
                LogUI.SetActive(false);
                break;
        }

    }

}
