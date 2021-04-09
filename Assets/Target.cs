
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50.0f;

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
