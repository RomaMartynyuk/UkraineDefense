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
        if (!target.isUpgraded)
        {
            upgradeCost.text = "₴" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "МАХ";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "₴" + target.turretBlueprint.GetSellAmount();

        rangeCircle.transform.localScale = new Vector3(target.GetRange() * 2, target.GetRange() * 2, target.GetRange() * 2);

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
