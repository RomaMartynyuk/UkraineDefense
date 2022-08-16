using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 10;

    public int moneyGain;

    public GameObject deathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        PlayerStats.money += moneyGain;

        GameObject deathEffectEnemy = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffectEnemy, 2f);
        
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
        Destroy(gameObject);
    }
}
