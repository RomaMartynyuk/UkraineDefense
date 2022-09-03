using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] Text livesText;
    private void Update()
    {
        livesText.text = PlayerStats.lives.ToString();
    }
}
