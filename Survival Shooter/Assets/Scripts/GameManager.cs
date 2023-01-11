using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IEnumerator
{
    private static bool timeStop = false;
    private static GameManager instance;
    public GameObject menu;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private int score = 0;
    public static bool isGameover { get;  set; } = true;

    public object Current => throw new System.NotImplementedException();

    private void Awake()
    {
        //if (instance != this)
        //{
        //    Destroy(gameObject);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<PlayerHeath>.onDeath += EndGame;
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            UIManager.Instance.UpdateScoreText(score);
        }
    }

    public void EndGame()
    {
        isGameover = true;
        UIManager.Instance.SetActiveGameoverUI(true);
    }



    public void Update()
    {
        //Time.timeScale = 0;

        if (Input.GetKeyUp(KeyCode.Escape) && !timeStop)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            timeStop = true;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && timeStop)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            timeStop = false;
        }

        if (!isGameover)
           StartCoroutine( ResetGame());
    }

    public IEnumerator ResetGame()
    {
       yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(gameObject.scene.name);
        isGameover = true;
    }

    public bool MoveNext()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        timeStop = false;
    }
    static public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
