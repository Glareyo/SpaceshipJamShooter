using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text points;

    public void Setup(int score)
    {
        points.text = "Score: " + score.ToString();
    }

    public void PlayGame()
    {
        Debug.Log("You've started the game.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("You've quit the game.");
        Application.Quit();
    }
}
