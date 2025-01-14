using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;   
using RandomNameGen;

public class Networker : MonoBehaviour {

    private RandomName randomName = new RandomName(new System.Random());
    private System.Random rand = new System.Random();
    
    public void saveData(int value){
        StartCoroutine(MakeRequests(value));
    }

    private IEnumerator MakeRequests(int value) {
        // Increment the value for testing
        value = value + 1;
        string scorevalue = value.ToString();

        // Declare the dataToPost dictionary outside the if-else block
        Dictionary<string, string> dataToPost;

        // Check if PlayerPrefs has a PlayerName key
        if (PlayerPrefs.HasKey("PlayerName")) {
            dataToPost = new Dictionary<string, string> {
                { "sname", PlayerPrefs.GetString("PlayerName") },
                { "score", scorevalue }
            };
        } else {
            // Ensure `decider` variable is defined
            int decider = rand.Next(0, 2); // Randomly choose 0 or 1
            var newName = randomName.Generate(
                decider == 0 ? RandomNameGen.Sex.Male : RandomNameGen.Sex.Female, 
                0, 
                false
            );
            dataToPost = new Dictionary<string, string> {
                { "sname", newName },
                { "score", scorevalue }
            };
            PlayerPrefs.SetString("PlayerName", newName);
        }

        Debug.Log("Welcome, " + PlayerPrefs.GetString("PlayerName") + "!");
        Debug.Log(dataToPost);

        // Create and send the POST request
        var postRequest = CreateRequest("http://127.0.0.1/database_handler.php", RequestType.POST, dataToPost);
        yield return postRequest.SendWebRequest();

        // Handle the response
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
