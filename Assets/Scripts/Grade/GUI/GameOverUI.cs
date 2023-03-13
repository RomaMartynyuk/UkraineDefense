using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Text roundOver;
    [SerializeField] Text roundAmount;

    [SerializeField] WaveSpawner waveSpawner;

    [SerializeField] private string menuSceneName = "MainMenu";

    [SerializeField] private SceneFader sceneFader;

    private void OnEnable()
    {
        roundOver.text = PlayerStats.rounds.ToString();
        roundAmount.text = "/" + waveSpawner.waves.Length.ToString();
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        WaveSpawner.enemiesAlive = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        WaveSpawner.enemiesAlive = 0;
        sceneFader.FadeTo(menuSceneName);
    }
}
