/*
 * FileName: Target.cs
 * Purpose: Implement basic health and damage scripts
 * Date: 4/14/21                                        */

using UnityEngine;
using UnityEngine.UI;

public class Target : Agent
{
    public float scoreModifier = 50000;
    public Canvas healthBar;
    public Image healthImage;
    public Vector3 postion = Vector3.zero;

    public float maxHealthConst = 5;  // This is the width of the image object used to represent zombies health bar. Used in calculating how much bar to display based on health

    public void takeDamage(float amount)
    {
        health -= amount;

        healthImage.rectTransform.sizeDelta = new Vector2((health / maxHealth * maxHealthConst), 1.0f);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Player.inst.score += scoreModifier / UIMgr.inst.waveClock;
        Destroy(gameObject);
    }
}
