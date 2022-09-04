using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    [SerializeField] private SceneFader sceneFader;

    [SerializeField] private string menuSceneName = "MainMenu"; 
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        Toggle();
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        Toggle();
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }
}
