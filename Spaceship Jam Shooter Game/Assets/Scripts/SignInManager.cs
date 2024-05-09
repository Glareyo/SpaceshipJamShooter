// Sign In Handler Credits: https://discussions.unity.com/t/connect-unity-to-sql-and-select-data-update/137573/2 

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class SignInManager : MonoBehaviour
{
    public GameObject startScreen, signInScreen;
    string username, password;
    string signInUrl = "http://localhost/SpaceshipJamShooterWebAndDatabase/UnitySignIn.php";

    public TMP_Text label, currentUser;
    public TMP_InputField inputUsername, inputPassword;
    public static GameObject correctUser;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(false);
        signInScreen.SetActive(true);
    }

    public void OnSignIn()
    {
        username = inputUsername.text;
        password = inputPassword.text;
        StartCoroutine(HandleSignIn());
    }

    IEnumerator HandleSignIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(signInUrl, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
                label.text = "Invalid Username/Password";
            }
            else
            {
                Debug.Log("Form upload complete!");
                label.text = "Success!";
                signInScreen.SetActive(false);
                startScreen.SetActive(true);
                currentUser.text += $" {username}!";
                correctUser = new GameObject($"{username}");
                correctUser.tag = "username";
                DontDestroyOnLoad( correctUser );
            }
        }
    }
}
