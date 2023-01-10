using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public int score = 0;
    public static UIManager Instance 
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }         
    }

    public TextMeshProUGUI scoreText;    
    public GameObject gameoverUI;
    public GameObject HitEffectUI;

    public void UpdateScoreText(int newScore)
    {              
        score += newScore;
        scoreText.text = "SCORE: " + score;
    }
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }
    //public void SetActiveHitEffect(bool active)
    //{
    //    HitEffectUI.SetActive(active);
    //}

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
