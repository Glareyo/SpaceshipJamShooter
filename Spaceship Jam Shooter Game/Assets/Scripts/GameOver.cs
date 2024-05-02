using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public Text points;

    public void Setup(string score)
    {
        gameOver.SetActive(true);
        points.text = "Score: " + score;
    }

    public void PlayGame()
    {
        Debug.Log("You've started the game.");
        SceneManager.LoadScene("PlanetMenu");
    }

    public void QuitGame()
    {
        Debug.Log("You've quit the game.");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
