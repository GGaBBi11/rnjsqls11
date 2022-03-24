using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public static TowerUI instance;

    private void Awake()
    {
        instance = this;
    }

    public Node node;

    public Text UpgradePriceText;
    public Text sellPriceText;

    private void OnDisable()
    {
        node = null;
        UpgradePriceText.text = "";
        sellPriceText.text = "";
    }
    public void OnUpgradeButton()
    {
        int nextLevel = node.tower.info.level + 1;
        if(TowerAssets.instance.TryGetTowerName(node.tower.info.type, nextLevel, out string towerName))
        {
            node.BuildTowerHere(towerName);
        }
    }

    public void OnSellButton()
    {
        node.DestroyTowerHere();
    }
}
