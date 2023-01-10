using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
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

    public Text scoreText;
    public GameObject gameoverUI;
    public GameObject HitEffectUI;

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "SCORE: " + newScore;
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
