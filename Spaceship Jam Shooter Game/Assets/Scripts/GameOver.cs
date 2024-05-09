using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public Text points;

    public void Setup(string score, string enemiesDestroyed, string meteorsDestroyed)
    {
        points.text = $"Score: {score}";
        points.text += $"\nEnemies Destroyed: {enemiesDestroyed}";
        points.text += $"\nMeteors Destroyed: {meteorsDestroyed}";

        gameOver.SetActive(true);

        DatabaseConnection.connectionState = ConnectionState.Connect;
        
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
