using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreMultiplier;

    public const string highScoreKey = "HighScore";

    private float score;

    void Update()
    {
        if (!GameManager.isGameOver)
        {
            score += Time.deltaTime * scoreMultiplier; // score increase by (seconds * multiplier)

            scoreText.text = Mathf.FloorToInt(score).ToString() + "m";
        }
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(highScoreKey, Mathf.FloorToInt(score));
        }

    }
}
