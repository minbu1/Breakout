using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static int score = 0;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public GameObject losePanel;
    public GameObject winPanel;

    void Update()
    {
        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";

        if(lives <= 0)
        {

            losePanel.SetActive(true);
            Time.timeScale = 0;
        }

        var bricks = FindObjectsOfType<Brick>().Length;

        if(bricks == 0) 
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
