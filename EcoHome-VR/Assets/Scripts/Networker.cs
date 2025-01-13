using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;   
public class Networker : MonoBehaviour
{
    public InputField id; 
    GameObject playerStatusPanel;
    public void GetData(string URL)
    {
        StartCoroutine(FetchData(URL));
    }
    void PostData(string URL, string data)
    {
        StartCoroutine(Upload(URL, data));
    }
    public IEnumerator FetchData(string URL)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                //PlayerStatus playerStat = new PlayerStatus();
                //playerStat = JsonUtility.FromJson<PlayerStatus>(request.downloadHandler.text);
                //Debug.Log("Erfolg, " playerStat);
                //playerStatusPanel.transform.GetChild(0).GetComponent<Text>().text = playerStat.playerName;
                //playerStatusPanel.transform.GetChild(1).GetComponent<Text>().text = "HP : " + playerStat.hp.ToString();
            }
        }
    }
    

    IEnumerator Upload(string URL, string data)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, data))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

/*
 
    SQLManager sqlManager = FindObjectOfType<SQLManager>();
    sqlManager.SendSQLCommand("INSERT INTO punkte (value) VALUES ('Wert2')");

 
 
 */
