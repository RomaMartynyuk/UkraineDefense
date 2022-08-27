using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

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
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        Debug.Log("Гру виграно");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        
    }
}
