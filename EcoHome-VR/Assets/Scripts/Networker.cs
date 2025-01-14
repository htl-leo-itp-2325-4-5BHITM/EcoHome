using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;   
public class Networker : MonoBehaviour {
    
    public void saveData(){

        StartCoroutine(MakeRequests());
    }

    private IEnumerator MakeRequests() {
    // POST
    var dataToPost = new Dictionary<string, string> {
        { "score", "8" }
    };
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
