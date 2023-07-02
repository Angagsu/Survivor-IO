using UnityEngine;


public class SawUpgrade : Upgrade
{
    [SerializeField] private Saw sawPrefab;
    public override void Apply(Player player)
    {
        var saw = Instantiate(sawPrefab, player.transform.position, Quaternion.identity);
        saw.transform.SetParent(player.transform, true);
    }

}
