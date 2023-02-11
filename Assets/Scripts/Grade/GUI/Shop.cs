using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint azov;
    public TurretBlueprint tornado;
    public TurretBlueprint zsu;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectAzov()
    {
        buildManager.SelectTurretToBuild(azov);
    }
    public void SelectZSU()
    {
        buildManager.SelectTurretToBuild(zsu);
    }
    public void SelectTornado()
    {
        buildManager.SelectTurretToBuild(tornado);
    }
}
