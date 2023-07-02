using UnityEngine;


public class RocketUpgrade : Upgrade
{
    [SerializeField] private RocketLauncher RocketLauncherPrefab;
    public override void Apply(Player player)
    {
        var rocket = Instantiate(RocketLauncherPrefab, player.transform.position, Quaternion.identity);
        rocket.transform.SetParent(player.transform, true);
    }
}
