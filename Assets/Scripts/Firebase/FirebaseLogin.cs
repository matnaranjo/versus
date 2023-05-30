using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Extensions;
using Firebase.Auth;
using UnityEngine.UI;
using Google;
using System.Net.Http;
using Unity.VisualScripting.Dependencies.NCalc;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class FirebaseLogin : MonoBehaviour
{
    public string GoogleWebApi = "293116740880-6530asg93o3kg8cr9tkthn92bje4k8aa.apps.googleusercontent.com";
    private GoogleSignInConfiguration configuration;

    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    UserToBin binFunctions;
    [SerializeField]
    GameObject binObject;
    [SerializeField]
    TextMeshProUGUI text;

    UserName playerName = new UserName();

    public GameObject startBtn;
    public GameObject creditBtn;

    private void Awake()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = GoogleWebApi,
            RequestIdToken = true
        };
    }


    void Start()
    {
        text.text = "aca 1";
        binFunctions = binObject.GetComponent<UserToBin>();
        InitFirebase();

        GoogleSignInClick();
    }

    void InitFirebase() 
    {
        text.text = "aca 2";

        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void GoogleSignInClick ()
    {
        text.text = "aca 3";

        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        GoogleSignIn.Configuration.RequestEmail = true;

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnGoogleAuthenticatedFinished);

    }

    void OnGoogleAuthenticatedFinished(Task<GoogleSignInUser> task)
    {
        text.text = "aca 4";
        
        if (task.IsFaulted)
        {
            text.text = "aca 5" + task.Exception;

            Debug.LogError("Fault" + task.Exception);
        }
        else if (task.IsCanceled)
        {
            text.text = "aca 6";

            Debug.LogError("LoginScreen Cancel");
        }
        else
        {
            text.text = "aca 7";
            Firebase.Auth.Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(task.Result.IdToken, null);
            auth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled)
                {
                    text.text = "aca 8";

                    Debug.LogError("SignInWithCredentialAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    text.text = "aca 9";

                    Debug.LogError("SignInwithCredentialAsync encountered an error: " + task.Exception);
                    return;
                }
                user = auth.CurrentUser;
                text.text = user.UserId;

                // Save user and name in binary file
                binFunctions.SaveUserInfoFirstTime(user.UserId, user.DisplayName);

                text.text = playerName.GetName();

                // Show start button
                startBtn.SetActive(true);
                creditBtn.SetActive(true);

            });
        }

    }
}
