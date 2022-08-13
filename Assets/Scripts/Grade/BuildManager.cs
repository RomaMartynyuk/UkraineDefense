using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Більше одного менеджера в сцені!!!");
            return;
        }
        instance = this;
    }
    public GameObject azovTurretPrefab;
    public GameObject mofTurretPrefab;
    public GameObject tornadoTurretPrefab;
    
    private GameObject turretToBuild;
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
