using System.Collections.Generic;
using UnityEngine;


public class UpgradesUIManager : MonoBehaviour
{
    [SerializeField] private UpgradeUI upgradeUIPrefab;
    [SerializeField] private UpgradesManager upgradesManager;

    public void Show(List<Upgrade> upgrades, Player player)
    {
        gameObject.SetActive(true);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var upgrade in upgrades)
        {
            var ui = Instantiate(upgradeUIPrefab, transform);
            ui.Setup(upgrade.title, upgrade.icon, () => OnClickApply(upgrade, player));
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnClickApply(Upgrade upgrade, Player player)
    {
        upgrade.Apply(player);
        upgradesManager.OnUpgradeApplyed(upgrade);
    }
}
