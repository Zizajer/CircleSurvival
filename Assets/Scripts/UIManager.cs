using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int highscore;
    public Text HighScoreText;
    public Button MenuButton;
    public Text NewHighscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);

        highscore = PlayerPrefs.GetInt("HighScore");

        if (HighScoreText != null)
            HighScoreText.text = highscore.ToString();
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ShowEndGameUIAnimations(int currentScore)
    {
        MenuButton.gameObject.SetActive(true);
        
        if(currentScore > highscore)
        {
            NewHighscoreText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
