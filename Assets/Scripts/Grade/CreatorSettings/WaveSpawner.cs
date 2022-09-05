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

    public GameManager gameManager;

    private int waveNumber = 0;

    private void Start()
    {
        enemiesAlive = 0;
    }
    private void Update()
    {
        if (enemiesAlive > 0)
            return;
        if (waveNumber == waves.Length && enemiesAlive <= 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0)
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
        PlayerStats.rounds++;

        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count.Length; i++)
        {
            for(int j = 0; j < wave.count[i]; j++)
            {
                SpawnEnemy(wave.enemy[i]);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        waveNumber++;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawn.position, spawn.rotation);
        enemiesAlive++;
    }
}
