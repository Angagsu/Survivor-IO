using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    [SerializeField] private int amountOfExperience;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            player.AddExperience(amountOfExperience);
            Destroy(gameObject);
        }
    }
}
