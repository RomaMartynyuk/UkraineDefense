using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject levelCompleteUI;

    public int levelToUnlock = 2;

    private void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if(GameIsOver)
            return;
        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }       
    }
    void EndGame()
    {
        Time.timeScale = 0f;
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        GameIsOver = true;
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        levelCompleteUI.SetActive(true);
    }
}
