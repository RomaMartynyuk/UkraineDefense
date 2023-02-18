using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms;

public class Rocket : MonoBehaviour
{
    public bool isLaunched = false;
    float speed = 30f;
    string enemyTag = "Enemy";
    int damage = 1000; 
    private Transform target;
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void Update()
    {
        if (target == null)
            return;
        //Vector3 dir = target.position - transform.position;
        //float distanceThisFrame = speed * Time.deltaTime;
        //if (dir.magnitude <= distanceThisFrame)
        //{
        //    HitTarget();
        //    return;
        //}
        if (Vector3.Distance(transform.position, target.position) < 1)
        {
            HitTarget();
            return;
        }
        if (isLaunched)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);
        }
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //float shortestDistance = Mathf.Infinity;
        //GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            target = enemy.transform;
        }
        
    }
    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        TutorialEnemy te = enemy.GetComponent<TutorialEnemy>();
        if (te != null)
        {
            te.TakeDamage(damage);
        }
    }
}
