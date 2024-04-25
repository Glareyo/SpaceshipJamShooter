using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseConnection : MonoBehaviour
{
    public void SettingSaveData()
    {
        StartCoroutine(SetSaveData());
    }

    IEnumerator SetSaveData()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", DatabaseManager.id);
        form.AddField("missionsComplete", DatabaseManager.missionsComplete);
        form.AddField("enemiesFought", DatabaseManager.enemiesFought);
        form.AddField("shipUpgrades", DatabaseManager.shipUpgrades);

        //                                       *****REPLACE THIS FOR WHEN THE PHP FILE CONTAINS THE INFO TO CONNECT*******
        using (UnityWebRequest www = UnityWebRequest.Post("https://localhost/sqlconnect/addgameinfo.php", form))
        {
            yield return www.SendWebRequest();
        }

    }


}

public class DatabaseManager
{
    public static int id;
    public static int missionsComplete;
    public static int enemiesFought;
    public static int shipUpgrades;

}

