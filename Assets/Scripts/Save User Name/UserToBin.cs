using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;


public class UserToBin : MonoBehaviour
{
    // Dictionary obtained from the binary, or created if no bin is found
    Dictionary<string, string> UserDic = new Dictionary<string, string>();
    // Dictionary path
    string filePath;

    UserName playerName = new UserName();

    void Awake(){
        filePath = Path.Combine(Application.persistentDataPath, "UserInfo.dic");
    }


    public void SaveUserInfoFirstTime(string id, string name){
        // if the file exists, that means the user changed gmail accounts
        // We have to make sure the Id is new to store a new entry
        // If the Id exists in the file, we just take the stored name
        if (File.Exists(filePath)){
            #region Get the stored Dictionary as binary
            BinaryFormatter bin = new BinaryFormatter();
            FileStream fileStream = File.Open(filePath, FileMode.Open);
            UserDic = bin.Deserialize(fileStream) as Dictionary<string, string>;
            fileStream.Close();
            #endregion
            
            string existingName;
            // If the id exists in the dictionary, get the name stored there
            if (UserDic.TryGetValue(id, out existingName)){
                playerName.SetName(existingName);
            }
            else{
                SaveUser(id,name);
                playerName.SetName(name);
            }
        }
        // If the file doesn't exists, it means is the first time the user opens the game
        // We store the name of the user based on his ID, in order to be able to change it later
        else{
            // Store user Id and name to be shown in the next scenes
            SaveUser(id, name);
            playerName.SetName(name);
        }
    }


    // public string ReadUser(){
    //     if (File.Exists(filePath)){
    //         #region Get the stored Dictionary as binary
    //         BinaryFormatter bin = new BinaryFormatter();
    //         FileStream fileStream = File.Open(filePath, FileMode.Open);
    //         UserDic = bin.Deserialize(fileStream) as Dictionary<string, string>;
    //         fileStream.Close();
    //         #endregion

    //         return UserDic[UserInfoObj.GetUserInfo()[0]];
    //     }

    //     else{
    //         return "No_Name_Found";
    //     }
    // }


    private void SaveUser(string sId, string sName){
        // Create the entry in the dictionary
        UserDic[sId] = sName;
        // initialize the formatter
        BinaryFormatter bin = new BinaryFormatter();
        // create a conection to that path with that file name "UserInfo.dic"
        FileStream fileStream = File.Create(filePath);
        // Serialize the dictionary and send it to the path selected
        bin.Serialize(fileStream, UserDic);
        fileStream.Close();
    }


}
