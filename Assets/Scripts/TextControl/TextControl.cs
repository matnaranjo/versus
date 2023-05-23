using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class TextControl : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI errorText;


    public static string isTextFine(string user, string pass){
        string errorMessage = null;
        string emptySpace = "\u200B";

        user = user.Replace(emptySpace,"");
        pass = pass.Replace(emptySpace,"");
        if (string.IsNullOrEmpty(user)||string.IsNullOrEmpty(pass)){
            errorMessage = "All fields are required";
            return errorMessage;
        }
        else if (!Regex.IsMatch(pass, @"\d") || !Regex.IsMatch(pass, @"[A-Z]")){
            errorMessage = "Password needs at least one capital letter and one number";
            return errorMessage;
        }
        else if (pass.Length<8){
            errorMessage = "Password needs to be at least 8 characters long";
            return errorMessage;
        }
        else if (user.Length<4){
            errorMessage = "User needs to be at least 4 characters long";
            return errorMessage;
        }
        else {
            return errorMessage;
        }
    }




}
