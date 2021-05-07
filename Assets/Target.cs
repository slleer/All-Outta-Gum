/*
 * Filename: Target.cs
 * Purpose: Implement health and damage
 * Date: 4/14/21                        */

using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float scoreModifier;
    public Canvas healthBar;
    public Image healthImage;
    public float timeToDie = 1.5f;
    public bool dead = false;
    public int ID;
    public Vector3 postion = Vector3.zero;

    public void Update()
    {
        if(dead)
        {
            timeToDie -= Time.deltaTime;
            if(timeToDie <= 0)
            {
                ZombieMgr.inst.zombies.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }

    public float maxHealthConst = 5;  // This is the width of the image object used to represent zombies health bar. Used in calculating how much bar to display based on health

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthImage.rectTransform.sizeDelta = new Vector2((health / maxHealth * maxHealthConst), 1.0f);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Player.inst.score += scoreModifier / UIMgr.inst.waveClock;
        //Animation ani = gameObject.GetComponent<Animation>();
        //ani.Play("zombie_death_standing");
        dead = true;
        //ZombieMgr.inst.zombies.Remove(gameObject);
        //Destroy(gameObject);
    }
}
