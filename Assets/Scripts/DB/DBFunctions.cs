using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DBFunctions : MonoBehaviour
{
    
    #region UIVariables
    public TextMeshProUGUI userSign;
    public TextMeshProUGUI passSign;
    public TextMeshProUGUI userLog;
    public TextMeshProUGUI passLog;
    public TextMeshProUGUI infoTextSign;
    public TextMeshProUGUI infoTextLog;
    public GameObject loading;
    #endregion

    public Server server;
    public dbUser dbUser;

    #region SignIn
    public void SignInFunc(){
        StartCoroutine(SignInRoutine());
    }

    public IEnumerator SignInRoutine(){
        loading.SetActive(true);

        string[] data = new string[2];
        data[0] = userSign.text;
        data[1] = passSign.text;

        StartCoroutine(server.consumeService("register", data, SignInResult));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(()=>!server.busy);

        loading.SetActive(false);
    }

    public void SignInResult(){
        if (server.answer.code == 201){
            dbUser = JsonUtility.FromJson<dbUser>(server.answer.answer);
            SceneManager.LoadScene("loading");
        }

        else{
            StartCoroutine(SignInInfoText());
        }
    }

    public IEnumerator SignInInfoText(){
        infoTextSign.color = Color.red;
        infoTextSign.text = server.answer.message;
        yield return new WaitForSeconds(3.0f);
        infoTextSign.text = "";
    }

    #endregion


    #region LogIn

    public void LogInFunc(){
        StartCoroutine(LogInRoutine());
    }

    public IEnumerator LogInRoutine(){
        loading.SetActive(true);

        string[] data = new string[2];
        data[0] = userLog.text;
        data[1] = passLog.text;

        StartCoroutine(server.consumeService("login", data, LogInResult));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(()=>!server.busy);

        loading.SetActive(false);
    }
    public void LogInResult(){
        if (server.answer.code == 205){
            dbUser = JsonUtility.FromJson<dbUser>(server.answer.answer);
            SceneManager.LoadScene("loading");
        }

        else{
            StartCoroutine(LogInInfoText());
        }
    }

    public IEnumerator LogInInfoText(){
        infoTextLog.color = Color.red;
        infoTextLog.text = server.answer.message;
        yield return new WaitForSeconds(3.0f);
        infoTextLog.text = "";
    }


    #endregion

}
