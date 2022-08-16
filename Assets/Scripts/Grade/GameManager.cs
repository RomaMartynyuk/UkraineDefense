using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isEnded = false;
    void Update()
    {
        if(isEnded)
            return;
        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }       
    }
    void EndGame()
    {

    }
}
