using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;   
using RandomNameGen;

public class Networker : MonoBehaviour {
    
    RandomName randomName = new RandomName(new System.Random());
    System.Random rand = new System.Random();
    public void saveData(int value){
        StartCoroutine(MakeRequests(value));
    }

    private IEnumerator MakeRequests(int value) {
    // POST
    value = value +1 ;
    string scorevalue = value.ToString();
    
    int decider = rand.Next(0, 1);

    var dataToPost = new Dictionary<string, string> {
        { "sname", randomName.Generate(decider == 0 ? RandomNameGen.Sex.Male : RandomNameGen.Sex.Female, 0, false) },
        { "score", scorevalue }
    };

    /*if(decider == 0){
        dataToPost = new Dictionary<string, string> {
        { "sname", randomName.Generate(RandomNameGen.Sex.Male, 0, false) },
        { "score", scorevalue }
        };
    }else{
        dataToPost = new Dictionary<string, string> {
            { "sname", randomName.Generate(RandomNameGen.Sex.Female, 0, false) },
            { "score", scorevalue }
        };
    }*/
    
    Debug.Log(dataToPost);
    var postRequest = CreateRequest("http://127.0.0.1/database_handler.php", RequestType.POST, dataToPost);
    yield return postRequest.SendWebRequest();

    if (postRequest.result == UnityWebRequest.Result.Success) {
        Debug.Log("Response: " + postRequest.downloadHandler.text);
    } else {
        Debug.LogError("Error: " + postRequest.error);
    }
    }

    private UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, Dictionary<string, string> data = null) {
        UnityWebRequest request;

        if (type == RequestType.POST && data != null) {
            request = UnityWebRequest.Post(path, data);
        } else {
            request = new UnityWebRequest(path, type.ToString());
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        Debug.Log(request);
        return request;
    }

        private void AttachHeader(UnityWebRequest request,string key,string value)
        {
           request.SetRequestHeader(key, value);
        }

}
public enum RequestType {
    GET = 0,
    POST = 1,
    PUT = 2
}


public class Todo {
    // Ensure no getters / setters
    // Typecase has to match exactly
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[Serializable]
public class PostData {
    public string Hero;
    public int PowerLevel;
}

public class PostResult
{
    public string success { get; set; }
}
/*
 
    SQLManager sqlManager = FindObjectOfType<SQLManager>();
    sqlManager.SendSQLCommand("INSERT INTO punkte (value) VALUES ('Wert2')");

 
 
 */
