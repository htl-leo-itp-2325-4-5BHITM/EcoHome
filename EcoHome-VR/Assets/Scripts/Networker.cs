using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SQLManager : MonoBehaviour
{
    [SerializeField] private string phpUrl = "kommt noch!";

    public void SendSQLCommand(string sqlCommand)
    {
        StartCoroutine(SendSQLRequest(sqlCommand));
    }

    private IEnumerator SendSQLRequest(string sqlCommand)
    {
        // Daten vorbereiten
        WWWForm form = new WWWForm();
        form.AddField("sql", sqlCommand);

        using (UnityWebRequest www = UnityWebRequest.Post(phpUrl, form))
        {
            // Anfrage senden
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("SQL Command executed: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}

/*
 
    SQLManager sqlManager = FindObjectOfType<SQLManager>();
    sqlManager.SendSQLCommand("INSERT INTO punkte (value) VALUES ('Wert2')");

 
 
 */
