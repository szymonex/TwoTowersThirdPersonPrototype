using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    /// <summary>
    /// Singleton
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    ///////////////////////////////////////

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private int targetsCountToWin = 3;

    [HideInInspector] public int jumpsCounter = 0;
    [HideInInspector] public int shotDownObjectsCounter = 0;
    private float gameStartTime;

    private void Start()
    {
        gameStartTime = Time.time;
    }

    private void Update()
    {
        GameTimeCounterUpdate();
    }

    public void JumpsCounterUpdate()
    {
        jumpsCounter++;
        UIManager.Instance.JumpsCounterTextUpdate();
    }

    public void ShotDownObjectsCounterUpdate()
    {
        shotDownObjectsCounter++;
        UIManager.Instance.TargetsCounterTextUpdate();
        GameWinCheck();
    }

    public void GameTimeCounterUpdate()
    {
        float timer = Time.time - gameStartTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = (int)timer % 60;
        UIManager.Instance.GameTimeCounterTextUpdate(minutes, seconds);
    }

    public void ShowGameOverPanel()
    {
        Cursor.lockState = CursorLockMode.None;
        gameOverPanel.gameObject.SetActive(true);
    }

    private void GameWinCheck()
    {
        if(shotDownObjectsCounter >= targetsCountToWin)
        {
            ShowGameOverPanel();
            gameOverText.text = "You Win!";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
