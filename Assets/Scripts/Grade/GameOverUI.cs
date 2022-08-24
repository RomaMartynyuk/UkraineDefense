using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Text roundOver;

    [SerializeField] private string menuSceneName = "MainMenu";

    [SerializeField] private SceneFader sceneFader;

    private void OnEnable()
    {
        roundOver.text = PlayerStats.rounds.ToString() + "/10";
    }
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
