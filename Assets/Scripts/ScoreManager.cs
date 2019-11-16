using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    private int currentScore;
    public int CurrentScore { get => currentScore;}
    
    void Update()
    {
        currentScore = (int) Time.timeSinceLevelLoad;
        ScoreText.text = CurrentScore.ToString();
    }
}
