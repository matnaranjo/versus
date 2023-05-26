using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void changeScene(string scene){
        StartCoroutine(SceneChangeCR(scene));
        
    }


    IEnumerator SceneChangeCR(string scene){
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(scene);
    }
}
