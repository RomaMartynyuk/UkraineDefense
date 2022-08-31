using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [Header("First level")]
    public GameObject prefab;
    public int cost;

    [Header("Second level")]
    public GameObject firstUpgradedPrefab;
    public int firstUpgradeCost;

    [Header("Third level")]
    public GameObject secondUpgradedPreFab;
    public int secondUpgradeCost;

    [Header("Fourth level")]
    public GameObject thirdUpgradedPreFab;
    public int thirdUpgradeCost;

    [Header("Hero level")]
    public GameObject HeroPreFab;
    public int HeroCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
    public int GetSellFirstUpgradeAmount()
    {
        return (cost + firstUpgradeCost ) / 2;
    }
    public int GetSellSecondUpgradeAmount()
    {
        return (cost + firstUpgradeCost + secondUpgradeCost ) / 2;
    }
    public int GetSellThirdUpgradeAmount()
    {
        return (cost + firstUpgradeCost + secondUpgradeCost + thirdUpgradeCost) / 2;
    }
    public int GetSellHeroUpgradeAmount()
    {
        return (cost + firstUpgradeCost + secondUpgradeCost + thirdUpgradeCost + HeroCost) / 2;
    }

}
