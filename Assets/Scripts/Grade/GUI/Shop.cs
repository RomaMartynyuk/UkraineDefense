using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint azov;
    public TurretBlueprint tornado;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectAzov()
    {
        buildManager.SelectTurretToBuild(azov);
    }
    //public void SelectMoF()
    //{
    //    buildManager.SelectTurretToBuild(mof);
    //}
    public void SelectTornado()
    {
        buildManager.SelectTurretToBuild(tornado);
    }
}
