using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;

    
    public static GameManager Instance
    {
        get
        {
            
            if (_instance == null)
            {
                
                _instance = FindFirstObjectByType<GameManager>();
                
            }
            
            return _instance;
        }
    }

    public TextMeshProUGUI scoreText;
    private int score = 0;

    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}