using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUpdater : MonoBehaviour
{
    [SerializeField] Text currentWave;
    [SerializeField] Text amountWaves;
    void Update()
    {
        currentWave.text = PlayerStats.rounds.ToString();
        amountWaves.text = "/" + WaveSpawner.amountWaves.ToString();
    }
}
