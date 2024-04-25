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

    private bool gameOver = false;

    private void Start()
    {
        lives = 3;
        score = 0;
    }

    void Update()
    {
        if (gameOver) return;

        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";

        if(lives <= 0)
        {

            losePanel.SetActive(true);
            gameOver = true;
            Invoke(nameof(Restart), 3);
        }

        var bricks = FindObjectsOfType<Brick>().Length;

        if(bricks == 0) 
        {
            winPanel.SetActive(true);
            gameOver = true;
            Invoke(nameof(Restart), 3);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
