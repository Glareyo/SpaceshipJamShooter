using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Lives = 5;
    public static int Score = 0;

    public Text LivesText, ScoreText;
    Vector2 livesLoc, scoreLoc;

    private static void SetupNewGame()
    {
        Lives = 5;
        Score = 0;
    }

    public void ScoreAdd()
    {
        Score = Score + 1;
    }

    public void ScoreReset()
    {
        Score = 0;
    }

    public void LivesSubtract()
    {
        Lives = Lives - 1;
    }

    public void LivesReset()
    {
        Lives = 5;
    }

    void Awake()
    {
        ScoreManager.SetupNewGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        LivesText.text = "Lives: " + ScoreManager.Lives.ToString();
        ScoreText.text = "Score: " + ScoreManager.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives: " + ScoreManager.Lives.ToString();
        ScoreText.text = "Score: " + ScoreManager.Score.ToString();
    }
}
