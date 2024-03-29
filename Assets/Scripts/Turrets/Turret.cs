using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Set-up Unity")]
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] string enemyTag = "Enemy";
   

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firepoint;

    [Header("ForUIInfo")]
    public string nameInUa;
    public string nameInEng;
    public int damageFromBullet;

    [Header("Shooting")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f;

    [Header("Animation")]
    public Animator animator;
    public Animator gunanim;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 1f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        if (target == null)
            return;
        
        LookOnTarget();

        FireManager();
    }
    void LookOnTarget()
    {
        Vector3 dir = transform.position - target.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void FireManager()
    {
        if(fireCountdown <= 0f)
        {
            animator.SetTrigger("ShootAnim");
            gunanim.SetTrigger("GunAnim");
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bulletGO != null)
        {
            bullet.Seek(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
