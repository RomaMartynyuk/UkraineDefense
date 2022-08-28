using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEnemy : MonoBehaviour
{
    public float speed = 10f;

    public float startHealth = 10f;
    private float health;

    public int moneyGain;

    public GameObject deathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    private void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        PlayerStats.money += moneyGain;

        GameObject deathEffectEnemy = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffectEnemy, 2f);

        WaveSpawner.enemiesAlive--;
        
        Destroy(gameObject);
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }
    void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
