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
            Debug.LogError("������ ������ ��������� � ����!!!");
            return;
        }
        instance = this;
    }
    public GameObject azovTurretPrefab;
    public GameObject mofTurretPrefab;
    public GameObject tornadoTurretPrefab;
    
    private TurretBlueprint turretToBuild;
    
    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("���� ������!");
            return;
        }
        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("���������� �����: " + PlayerStats.money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
