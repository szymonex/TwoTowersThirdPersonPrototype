using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
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

    public TMP_Text jumpsCounterText;
    public TMP_Text targetsCounterText;
    public TMP_Text gameTimeCounterText;

    public void JumpsCounterTextUpdate()
    {
        jumpsCounterText.text = GameManager.Instance.jumpsCounter.ToString();
    }

    public void TargetsCounterTextUpdate()
    {
        targetsCounterText.text = GameManager.Instance.shotDownObjectsCounter.ToString();
    }

    public void GameTimeCounterTextUpdate(int minutes, int seconds)
    {
        gameTimeCounterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
