using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BayraktarMoving : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float speed = 5f;
    [SerializeField] private List<Rocket> rockets;
    private float RocketWaitTime;
    private BayraktarSpawn bayraktarSpawn;
    private void Start()
    {
        bayraktarSpawn = FindObjectOfType<BayraktarSpawn>();
        targetPosition = bayraktarSpawn.targetTransform.position;
        transform.rotation = bayraktarSpawn.targetTransform.rotation;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 1)
        {
            bayraktarSpawn.canSpawn = true;
            Destroy(gameObject);
        }
        if (RocketWaitTime <= 0)
            RocketLaunch();
        else
            RocketWaitTime -= Time.deltaTime;
        if(rockets.Count <= 0)
            speed += 3 * Time.deltaTime;
    }
    void RocketLaunch()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 80)
        {
            foreach (var rocket in rockets)
            {
                rocket.isLaunched = true;
                RocketWaitTime = 2f;
                rockets.Remove(rocket);
                break;
            }
        }
    }
}
