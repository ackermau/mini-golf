using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// End screen text code
public class CreditScript : MonoBehaviour
{  
    // score of player
    public int score;
    // final text on screen
    public Text scoreText;
    void Start()
    {
        score = GameController.score;
        scoreText = GameObject.Find("ScoreLabel").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Nice Job! Your score is: " + score.ToString() + " out of 1500";
    }
}