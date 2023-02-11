using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BayraktarMoving : MonoBehaviour
{
    BayraktarSpawn bayraktarSpawn;
    [SerializeField] float speed = 10;
    private void Start()
    {
        transform.position = bayraktarSpawn.spawnTransform.position;
    }
    private void Update()
    {
        Vector3 dir = bayraktarSpawn.targetTransform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        toDestroy();
    }
    void toDestroy()
    {
        if (Vector3.Distance(transform.position, bayraktarSpawn.targetTransform.position) < 1)
        {
            Destroy(gameObject);
        }
    }
}
