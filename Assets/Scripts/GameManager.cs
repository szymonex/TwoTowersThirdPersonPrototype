using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void GameTimeCounterUpdate()
    {
        float timer = Time.time - gameStartTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = (int)timer % 60;
        UIManager.Instance.GameTimeCounterTextUpdate(minutes, seconds);
    }

}
