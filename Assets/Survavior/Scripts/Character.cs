using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] private float maxHealth;
    public float Health { get; private set; }

    public bool IsDead => Health <= 0;

    private void Awake()
    {
        Health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        Debug.Log("health changed: " + damage + ", health: " + Health + ", " + name);

        if (IsDead)
        {
            gameObject.SetActive(false);
            OnDead();
        }
    }
    
    protected virtual void OnDead()
    {
    }
}
