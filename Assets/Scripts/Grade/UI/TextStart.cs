using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStart : MonoBehaviour
{
    public Color textColor;
    void Start()
    {
        Text text = GetComponent<Text>();
        text.color = textColor;
    }
}
