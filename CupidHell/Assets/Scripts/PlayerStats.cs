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
        weaponType.Add(weapon_type.flamethrower, 0);
        weaponType.Add(weapon_type.pistol, 0);
        weaponType.Add(weapon_type.machinegun, 0);
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
                if(weaponType[weapon_type.pistol] > 0)
                {

                }
                break;
            case weapon_type.flamethrower:
                if (weaponType[weapon_type.flamethrower] > 0)
                {

                }
                break;
            case weapon_type.machinegun:
                if (weaponType[weapon_type.machinegun] > 0)
                {

                }
                break;
        }
    }

    public void ChargePower(string name)
    {

        switch (name.ToLower())
        {
            case "flamethrower":
                weaponType[weapon_type.flamethrower] += 0.25f;
                if (weaponType[weapon_type.flamethrower] > 1)
                    weaponType[weapon_type.flamethrower] = 1;
                break;
            case "pistol":
                weaponType[weapon_type.pistol] += 0.25f;
                if (weaponType[weapon_type.pistol] > 1)
                    weaponType[weapon_type.pistol] = 1;
                break;
            case "machinegun":
                weaponType[weapon_type.machinegun] += 0.25f;
                if (weaponType[weapon_type.machinegun] > 1)
                    weaponType[weapon_type.machinegun] = 1;
                break;
        }

        
    }
    
    public float GetPower(string name)
    {
        switch (name.ToLower())
        {
            case "flamethrower":
                return weaponType[weapon_type.flamethrower];
            case "pistol":
                return weaponType[weapon_type.pistol];
            case "machinegun":
                return weaponType[weapon_type.machinegun];
        }
        return 0;
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
