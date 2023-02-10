using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // score value as int
    public static int score;
    // number of lives as int
    public static int lives;
    // text for score on game screne
    private Text scoreText;
    // text for lives on game screne
    private Text livesText;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 5;
        scoreText = GameObject.Find("ScoreLabel").GetComponent<Text>();
        livesText = GameObject.Find("Lives").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 1500) {
            SceneManager.LoadScene(3);
        }
        if (lives > 0) {
            scoreText.text = "Score: " + score.ToString();
            livesText.text = "Lives: " + lives.ToString();
        }
        else {
            SceneManager.LoadScene(2);
        }
    }
}