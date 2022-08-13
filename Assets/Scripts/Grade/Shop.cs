using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseAzov()
    {
        buildManager.SetTurretToBuild(buildManager.azovTurretPrefab);
    }
    public void PurchaseMoF()
    {
        buildManager.SetTurretToBuild(buildManager.mofTurretPrefab);
    }
    public void PurchaseTornado()
    {
        buildManager.SetTurretToBuild(buildManager.tornadoTurretPrefab);
    }
}
