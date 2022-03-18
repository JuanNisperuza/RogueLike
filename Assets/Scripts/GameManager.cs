using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int time = 30;
    public int difficulty = 1;
    private int score;
    public bool gameOver = false;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.Instance.UpdateScore(score);
            if (score % 1000 == 0)
            {
                difficulty++;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
       // StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time++;
            UIManager.Instance.Updatetime(time);
        }
        gameOver = true;
        UIManager.Instance.ShowGameOverScreen();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}