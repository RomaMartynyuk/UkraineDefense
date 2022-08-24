using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLang : MonoBehaviour
{
    [HideInInspector] public string language;

    Text text;

    [SerializeField] private string textUa;
    [SerializeField] private string textEng;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        language = PlayerPrefs.GetString("language");
        if (language == "" || language == "Eng")
        {
            text.text = textEng;
        }
        else if (language == "Ua")
        {
            text.text = textUa;
        }
    }
}
