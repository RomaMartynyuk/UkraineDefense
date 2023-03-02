using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject rangeCircle;
    [SerializeField] GameObject uiInfo;

    private Node target;

    [SerializeField] Text sellAmount;

    [Header("InfoTurret")]
    [SerializeField] Text nameTurret;
    [SerializeField] Text damageText;
    [SerializeField] Text rangeText;
    [SerializeField] Text fireRateText;

    [Header("Upgrades")]
    [SerializeField] Text upgradeCost;
    [SerializeField] Button upgradeButton;
    public void SetTarget(Node target)
    {
        this.target = target;

        transform.position = target.GetBuildPosition();
        switch (target.numberOfLevel)
        {
            case 1:
                sellAmount.text = "₴" + target.turretBlueprint.GetSellAmount();
                upgradeCost.text = "₴" + target.turretBlueprint.firstUpgradeCost;
                upgradeButton.interactable = true;
                break;
            case 2:
                sellAmount.text = "₴" + target.turretBlueprint.GetSellFirstUpgradeAmount();
                upgradeCost.text = "₴" + target.turretBlueprint.secondUpgradeCost;
                upgradeButton.interactable = true;
                break;
            case 3:
                sellAmount.text = "₴" + target.turretBlueprint.GetSellSecondUpgradeAmount();
                upgradeCost.text = "₴" + target.turretBlueprint.thirdUpgradeCost;
                upgradeButton.interactable = true;
                break;
            case 4:
                sellAmount.text = "₴" + target.turretBlueprint.GetSellThirdUpgradeAmount();
                upgradeCost.text = "MAX";
                upgradeButton.interactable = false;
                break;
            default:
                break;
        }

        rangeCircle.transform.localScale = new Vector3(target.GetRange() * 2, 0, target.GetRange() * 2);

        InfoDisplayer();

        rangeCircle.SetActive(true);
        ui.SetActive(true);
        uiInfo.SetActive(true);
    }
    public void Hide()
    {
        rangeCircle.SetActive(false);
        ui.SetActive(false);
        uiInfo.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
    public void InfoDisplayer()
    {
        nameTurret.text = target.GetName();

        damageText.text = target.GetDamage().ToString();

        rangeText.text = target.GetRange().ToString();

        fireRateText.text = target.GetFireRate().ToString();
    }
}
