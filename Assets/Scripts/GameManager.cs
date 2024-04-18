using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static int score = 0;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";
    }
}
