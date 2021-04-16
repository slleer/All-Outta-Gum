/*
 * FileName: Target.cs
 * Purpose: Implement basic health and damage scripts
 * Date: 4/14/21                                        */

using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50.0f;
    public Canvas healthBar;
    public Image healthImage;
    public float maxHealthConst = 5;

    public void takeDamage(float amount)
    {
        health -= amount;

        healthImage.rectTransform.sizeDelta = new Vector2((health / 50.0f * maxHealthConst), 1.0f);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
