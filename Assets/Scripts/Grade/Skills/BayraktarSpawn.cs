using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayraktarSpawn : MonoBehaviour
{
    [SerializeField] GameObject bayraktarPreFab;
    public bool canSpawn = true;
    public Transform spawnTransform;
    public Transform targetTransform;
    [SerializeField] private float timeToSpawn = 30;
    private float realTimeSpawn;
    private void Start()
    {
        bayraktarPreFab.transform.position = spawnTransform.position;
    }
    private void Update()
    {
        if(!canSpawn)
            realTimeSpawn -= Time.deltaTime;
        if (realTimeSpawn <= 0)
            canSpawn = true;
    }
    public void SpawnBayraktar()
    {
        if (canSpawn)
        {
            Instantiate(bayraktarPreFab);
            realTimeSpawn = timeToSpawn;
            canSpawn = false;
        }
        if(!canSpawn)
            return;
    }
}
