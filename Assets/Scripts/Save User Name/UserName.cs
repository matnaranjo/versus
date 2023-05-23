using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserName
{
    public void SetName(string name){
        int spaceIndex = name.IndexOf(' ');
        string noSpaceName;

        if (spaceIndex != -1){
            noSpaceName = name.Substring(0, spaceIndex);
        }
        else{
            noSpaceName = name;
            if (name.Length>10){
                noSpaceName = name.Substring(10);
            }
        }

        PlayerPrefs.SetString("name", noSpaceName );
    }

    public string GetName(){
        string name =  PlayerPrefs.GetString("name");
        return name;
    }
}
