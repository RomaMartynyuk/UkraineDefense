using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawn;

    public Text waveCountdown;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveNumber = 0;

    private void Update()
    {
        if (enemiesAlive > 0)
            return;
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdown.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
        Debug.Log("Наближається нова партія ворогів!");
        
        PlayerStats.rounds++;

        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;
        if(waveNumber == waves.Length)
        {
            Debug.Log("Гру виграно");
            this.enabled = false;
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawn.position, spawn.rotation);
        enemiesAlive++;
    }
}
