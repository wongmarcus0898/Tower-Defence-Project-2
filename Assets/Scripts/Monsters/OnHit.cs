using UnityEngine;

public class OnHit : MonoBehaviour
{
    [SerializeField] private HealthBar healthbar;

    public int maxHealth;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void damageTaken(int damage)
    {
        healthbar.SetSize(maxHealth);
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
}
