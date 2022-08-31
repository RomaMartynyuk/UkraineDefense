using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]

    public int numberOfLevel = 1;
    private Renderer rend;

    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        turret = null;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBlueprint());
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Нема грошей!");
            return;
        }
        PlayerStats.money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        Debug.Log("Залишилось коштів: " + PlayerStats.money);
    }
    public void SellTurret()
    {
        if(numberOfLevel == 1)
            PlayerStats.money += turretBlueprint.GetSellAmount();
        else if(numberOfLevel == 2)
            PlayerStats.money += turretBlueprint.GetSellFirstUpgradeAmount();
        else if(numberOfLevel == 3)
            PlayerStats.money += turretBlueprint.GetSellSecondUpgradeAmount();
        else if(numberOfLevel == 4)
            PlayerStats.money += turretBlueprint.GetSellThirdUpgradeAmount();
        else if(numberOfLevel == 5)
            PlayerStats.money += turretBlueprint.GetSellHeroUpgradeAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        Destroy(turret);
        turretBlueprint = null;
    }
    public void UpgradeTurret()
    {
        if (numberOfLevel == 1)
        {
            if (PlayerStats.money < turretBlueprint.firstUpgradeCost)
            {
                return;
            }
            PlayerStats.money -= turretBlueprint.firstUpgradeCost;
            //Знищується стара моделька
            Destroy(turret);
            //Будується нова
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.firstUpgradedPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            numberOfLevel = 2;
        }
        else if(numberOfLevel == 2)
        {
            if (PlayerStats.money < turretBlueprint.secondUpgradeCost)
            {
                return;
            }
            PlayerStats.money -= turretBlueprint.secondUpgradeCost;
            //Знищується стара моделька

            Destroy(turret);
            
            //Будується нова
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.secondUpgradedPreFab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            numberOfLevel = 3;
        }
        else if(numberOfLevel == 3)
        {
            if (PlayerStats.money < turretBlueprint.thirdUpgradeCost)
            {
                return;
            }
            PlayerStats.money -= turretBlueprint.thirdUpgradeCost;
            //Знищується стара моделька

            Destroy(turret);

            //Будується нова
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.thirdUpgradedPreFab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            numberOfLevel = 4;
        }
        else if(numberOfLevel == 4)
        {
            if (PlayerStats.money < turretBlueprint.HeroCost)
            {
                return;
            }
            PlayerStats.money -= turretBlueprint.HeroCost;
            //Знищується стара моделька

            Destroy(turret);

            //Будується нова
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.HeroPreFab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 3f);

            numberOfLevel = 5;
        }
    }
    public string GetName()
    {
        if (PlayerPrefs.GetString("language") == "Ua")
            return turret.GetComponent<Turret>().nameInUa.ToString();
        if (PlayerPrefs.GetString("language") == "Eng" || PlayerPrefs.GetString("language") == "")
            return turret.GetComponent<Turret>().nameInEng.ToString();
        else
            return "none";
    }
    public int GetDamage()
    {
        return turret.GetComponent<Turret>().damageFromBullet;
    }
    public float GetRange()
    {
        return turret.GetComponent<Turret>().range;
    }
    public float GetFireRate()
    {
        return turret.GetComponent<Turret>().fireRate;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
