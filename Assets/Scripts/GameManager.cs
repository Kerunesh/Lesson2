using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int score = 0;
    private bool isOnPause = false;



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
        _menuScreen.SetActive(false);
        Time.timeScale = 1f;
        UpdateScoreText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_menuScreen.activeSelf || isOnPause)
            {
                TogglePause();
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        _scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
        isOnPause = true;
        _menuScreen.SetActive(true);
    }

    public void TogglePause ()
    {
        isOnPause = !isOnPause;
        _menuScreen.SetActive(isOnPause);

        if (isOnPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}