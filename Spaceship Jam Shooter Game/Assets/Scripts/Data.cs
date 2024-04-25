//Credits:
//Fire Brain Games (Creagines) -> Provided video tutorials on Unity Web Requests.
//https://www.youtube.com/watch?v=SO6KLuz_S8M

//Unity Documentation -> Provided Documentation on Unity Web Requests
//https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Post.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Diagnostics;

public class Data : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //This starts the Target IEnumerator
        //StartCoroutine(ExampleMethod("ExampleUser", "ExamplePassword"));
    }

    /// <summary>
    /// This is a Template method. Use to create new methods for data upload
    /// </summary>
    /// <param name="inputData">Target string / data to upload</param>
    IEnumerator UploadMethod(string inputData) // <-- TODO: Have parameters take in target data to upload
    {
        //Target the direct website
        //*DO NOT CHANGE UNLESS NEED TO*
        const string _WEBSITE = "http://localhost/SpaceshipJamShooterWebAndDatabase/";
        //Create a new form for the PHP page to read
        //*DO NOT CHANGE*
        WWWForm form = new WWWForm();

        //TODO
        //Target the PHP page that the data is sent to.
        //EXAMPLE: string TargetPage = "UnityConnectPage.php";
        string TargetPage = "";

        //TODO
        //Add to the form the target field, and the target data
        //EXAMPLE: form.AddField("username", "Nemo");
        //EXAMPLE: form.AddField("userpassword", "Password");
        form.AddField("", inputData);

        //Create a new UnityWebRequest.
        //*DO NOT CHANGE*
        using (UnityWebRequest www = UnityWebRequest.Post(_WEBSITE + TargetPage, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                //Debug.LogError(www.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");
            }
        }
    }

    /// <summary>
    /// This is an Example method that'll add a new user
    /// </summary>
    /// <param name="username">Input username</param>
    /// <param name="userpassword">Input Password</param>
    /// <returns></returns>
    IEnumerator ExampleMethod(string username, string userpassword)
    {
        //Target the direct website *DO NOT CHANGE UNLESS NEED TO*
        const string _WEBSITE = "http://localhost/SpaceshipJamShooterWebAndDatabase/";

        //Target the PHP page that the data is sent to.
        string TargetPage = "UnityConnectPage.php";


        //Create a new form for the PHP page to read
        WWWForm form = new WWWForm();

        //Add to the form the target field, and the target data
        //EXAMPLE: form.AddField(TargetField, Data);
        //EXAMPLE: form.AddField("username", "Nemo");
        form.AddField("username", username);
        form.AddField("userpassword", userpassword);

        //Create a new UnityWebRequest.
        using (UnityWebRequest www = UnityWebRequest.Post(_WEBSITE + TargetPage, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                //Debug.LogError(www.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");
            }
        }
    }
}