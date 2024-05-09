/*
    Credits:
    Script based on discussion forums:
    - https://forum.unity.com/threads/how-would-one-connect-a-unity-game-to-a-database-to-store-simple-amounts-of-data.606397/
    - https://discussions.unity.com/t/connect-unity-to-sql-and-select-data-update/137573

 */

using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;

public enum ConnectionState { Nothing, Connect}

public class DatabaseConnection : MonoBehaviour
{
    //Call during the win state

    public static ConnectionState connectionState;

    private void Start()
    {
        connectionState = ConnectionState.Nothing;
    }

    private void Update()
    {
        if(connectionState == ConnectionState.Connect)
        {
            DatabaseManager.username = GetCurrentUser();
            //DatabaseManager.id = 1; //It will always be the first ID
            DatabaseManager.score = ScoreManager.Score;
            UploadData();
        }
    }

    public string GetCurrentUser()
    {
        GameObject usernameObject = GameObject.FindGameObjectWithTag("username");
        return usernameObject.name;
    }

    public void UploadData()
    {
        StartCoroutine(SetSaveData());
    }

    IEnumerator SetSaveData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DatabaseManager.username);
        form.AddField("score", DatabaseManager.score);

        //                                     
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/SpaceshipJamShooterWebAndDatabase/UnityGame.php", form))
        {
            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                //Fail
            }
            else
            {
                //Success
            }
        }

    }


}

public class DatabaseManager : MonoBehaviour
{
    public static int score;
    public static int id;
    public static string username;
}

