using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private float maxHealth;
    public float baseHealth;
    private float health;

    public enum weapon_type
    {
        pistol,
        flamethrower,
        machinegun
    }

    public weapon_type Weapon;

    private Dictionary<weapon_type, float> weaponType;

    // Start is called before the first frame update
    void Start()
    {
        this.Weapon = weapon_type.pistol;
        this.maxHealth = baseHealth;
        this.health = this.maxHealth;

        this.weaponType = new Dictionary<weapon_type, float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        switch (Weapon)
        {
            case weapon_type.pistol:
                break;
            case weapon_type.flamethrower:
                break;
            case weapon_type.machinegun:
                break;
        }
    }

    public void ChargePower(string name)
    {

        switch (name.ToLower())
        {
            case "flamethrower":

                break;
        }

        Debug.Log("String name " + name.ToLower() + " is not a valid keyword for powerup --- Stack< UsePowerup(" + name + ") in PlayerStats.cs >");
    }
    


    public void DoDamage(float damage)
    {
        this.health -= damage;
    }

    public void DoContinuousDamage(float damage)
    {
        this.health -= damage * Time.deltaTime;
    }
                                                                                                  
    public void IncreaseHealth(float health)
    {
        this.health = (this.health + health > maxHealth ? maxHealth : this.health + health);
    }

    public void IncreaseHealthContinuous(float health)
    {
        this.health = (this.health + (health * Time.deltaTime) > maxHealth ? maxHealth : this.health + (health * Time.deltaTime));
    }

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public float GetHealth()
    {
        return this.health;
    }

    public float GetHealthProportion()
    {
        return this.health / this.maxHealth;
    }
}
