using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayraktarSpawn : MonoBehaviour
{
    [SerializeField] GameObject bayraktarPreFab;
    private bool canSpawn = true;
    public Transform spawnTransform;
    public Transform targetTransform;
    [SerializeField] private float timeToSpawn = 30;
    private float realTimeSpawn;
    private void Update()
    {
        realTimeSpawn -= Time.deltaTime;
    }
    public void SpawnBayraktar()
    {
        if (canSpawn)
        {
            Instantiate(bayraktarPreFab);
            canSpawn = false;
        }
        if(!canSpawn)
            return;
    }
}
