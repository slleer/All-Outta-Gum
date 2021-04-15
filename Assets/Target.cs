/*
 * FileName: Target.cs
 * Purpose: Implement basic health and damage scripts
 * Date: 4/14/21                                        */

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
