using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private UpgradesUIManager upgradesUiManager;
    [SerializeField] private Upgrade[] upgrades;
    [SerializeField] private Player player;

    private List<Upgrade> availableUpgrades;

    private void Awake()
    {
        availableUpgrades = upgrades.ToList();
    }
    public void SuggestToUpgrade()
    {
        if (availableUpgrades.Count > 0)
        {
            Time.timeScale = 0;
        }
        upgradesUiManager.Show(availableUpgrades, player);
    }

    public void OnUpgradeApplyed(Upgrade applyedUpgrade)
    {
        upgradesUiManager.Hide();
        availableUpgrades.Remove(applyedUpgrade);
        Time.timeScale = 1;
    }
}
