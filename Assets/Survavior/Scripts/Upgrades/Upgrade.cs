using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    public string title;
    public Sprite icon;

    public abstract void Apply(Player player);
}
