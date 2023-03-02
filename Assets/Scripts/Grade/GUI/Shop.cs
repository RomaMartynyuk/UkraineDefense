using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint azov;
    public TurretBlueprint tornado;
    public TurretBlueprint zsu;
    public TurretBlueprint rightSector;

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
    public void SelectRightSector()
    {
        buildManager.SelectTurretToBuild(rightSector);
    }
    public void Unselect()
    {
        buildManager.SelectTurretToBuild(null);
    }
}
