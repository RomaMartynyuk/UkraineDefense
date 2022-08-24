using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationManager : MonoBehaviour
{
    public void Eng()
    {
        string language = "Eng";
        PlayerPrefs.SetString("language", language);
    }
    public void Ua()
    {
        string language = "Ua";
        PlayerPrefs.SetString("language", language);
    }
}
