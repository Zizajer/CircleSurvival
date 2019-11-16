using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    private int currentScore;
    public int CurrentScore { get => currentScore; set => currentScore = value; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore = (int) Time.timeSinceLevelLoad;
        ScoreText.text = CurrentScore.ToString();
    }
}
