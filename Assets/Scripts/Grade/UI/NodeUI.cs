using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    [SerializeField] GameObject rangeCircle;
    [SerializeField] GameObject uiInfo;

    private Node target;

    public Text sellAmount;

    [Header("InfoTurret")]
    public Text nameTurret;
    public Text damageText;
    public Text rangeText;
    public Text fireRateText;

    [Header("Upgrades")]
    public Text upgradeCost;
    public Button upgradeButton;
    public void SetTarget(Node target)
    {
        this.target = target;

        transform.position = target.GetBuildPosition();
        if (target.numberOfLevel == 1)
        {
            sellAmount.text = "₴" + target.turretBlueprint.GetSellAmount();
            upgradeCost.text = "₴" + target.turretBlueprint.firstUpgradeCost;
            upgradeButton.interactable = true;
        }
        else if(target.numberOfLevel == 2)
        {
            sellAmount.text = "₴" + target.turretBlueprint.GetSellFirstUpgradeAmount();
            upgradeCost.text = "₴" + target.turretBlueprint.secondUpgradeCost;
            upgradeButton.interactable = true;
        }
        else if(target.numberOfLevel == 3)
        {
            sellAmount.text = "₴" + target.turretBlueprint.GetSellSecondUpgradeAmount();
            upgradeCost.text = "₴" + target.turretBlueprint.thirdUpgradeCost;
            upgradeButton.interactable = true;
        }
        else if(target.numberOfLevel == 4)
        {
            sellAmount.text = "₴" + target.turretBlueprint.GetSellThirdUpgradeAmount();
            upgradeCost.text = "₴" + target.turretBlueprint.HeroCost;
            upgradeButton.interactable = true;
        }
        else
        {
            sellAmount.text = "₴" + target.turretBlueprint.GetSellHeroUpgradeAmount();
            upgradeCost.text = "МАХ";
            upgradeButton.interactable = false;
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
