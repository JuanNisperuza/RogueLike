using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Slider healthSlide;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateScore(int scoreValue)
    {
        finalScore.text = scoreValue.ToString();
    }

    public void UpdateHealth(int healthValue)
    {
        healthSlide.value = healthValue;
    }

    public void Updatetime(int timeValue)
    {
        time.text = timeValue.ToString();
    }

    public void ShowGameOverScreen()
    {
        gameOver.SetActive(true);
    }
}