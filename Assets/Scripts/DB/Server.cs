using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[CreateAssetMenu (fileName ="server", menuName = "goomoonryong/server", order =1)]
public class Server : ScriptableObject
{
    public string server;   
    public Service[] services;
    public Answer answer;
    public bool busy = false;

    public IEnumerator consumeService(string service, string[] data, UnityAction e){
        busy = true;
        WWWForm form = new WWWForm();
        Service s = new Service();

        if (TextControl.isTextFine(data[0], data[1])==null){
            // Based on the services array, makes service equal to the one named in service variable.
            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].name.Equals(service)){
                    s=services[i];
                }
            }
            // create a form using the data submitted and the name of the parameter in s Service.
            for (int i = 0; i < s.parameters.Length; i++)
            {

                // Debug.Log(s.parameters[i]+"  " +data[i]);
                form.AddField(s.parameters[i], data[i]);
            }

            // Post the form to the php file
            UnityWebRequest www = UnityWebRequest.Post(server + "/" + s.URL, form);
            // Debug.Log(server+ "/"+s.URL);
            yield return www.SendWebRequest();
            // if the result is not successfull, show error in the answer.
            if (www.result != UnityWebRequest.Result.Success){
                answer = new Answer("Error");
            }
            // if the result is successfull, save the json file in the answer parameters.
            else{
                string answerJson = www.downloadHandler.text;
                answerJson = answerJson.Replace('#','"');
                // Debug.Log(answerJson);
                answer = JsonUtility.FromJson<Answer>(answerJson);
            }
        }

        else {
            answer = new Answer(TextControl.isTextFine(data[0], data[1]));
        }

        busy = false;
        e.Invoke();
        
    }
}



[System.Serializable]
    public class Service{
        public string name;
        public string URL;
        public string[] parameters;
}

[System.Serializable]
public class Answer{
    public int code;
    public string message;
    public string answer;

    public Answer(string msg){
        code = 404;
        message = msg;        
    }
}

[System.Serializable]
public class dbUser{

    public int id;
    public string user;
    public string password;
    public  int wins;
    public int defeats; 

}
