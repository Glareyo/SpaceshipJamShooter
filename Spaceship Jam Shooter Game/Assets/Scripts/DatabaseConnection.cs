using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseConnection : MonoBehaviour
{
    //Call during the win state
    public void SettingSaveData()
    {
        StartCoroutine(SetSaveData());
    }

    IEnumerator SetSaveData()
    {
        WWWForm form = new WWWForm();
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


    private void Update()
    {
        score = ScoreManager.Score;
    }

}

