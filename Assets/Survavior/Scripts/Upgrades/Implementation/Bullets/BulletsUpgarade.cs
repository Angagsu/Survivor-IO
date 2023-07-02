using UnityEngine;


public class BulletsUpgarade : Upgrade 
{
    [SerializeField] private int increment;

    public override void Apply(Player player)
    {
        player.BulletsCount += increment;
    }
}
