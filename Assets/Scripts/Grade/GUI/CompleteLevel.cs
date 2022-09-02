using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] string menuSceneName = "MainMenu";

    [SerializeField] SceneFader sceneFader;

    [SerializeField] Text roundText;
    private void OnEnable()
    {
        roundText.text = PlayerStats.rounds.ToString();
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
