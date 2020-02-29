using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_shield : MonoBehaviour
{

    public float start_angle;
    private float current_angle;

    public float angle_speed;

    public float shield_distance;

    public GameObject parent;

    public float MaxHealth;
    private float shield_health;

    public float rechargeTimer;

    private float currTimer;

    private float old_health;

    // Start is called before the first frame update
    void Start()
    {
        this.shield_health = MaxHealth;
        this.old_health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ComputeHealthRecharge();


    }

    private void Move()
    {
        current_angle += Time.deltaTime;

        //Calculate the angle as a vector
        Vector2 newPos = new Vector2(Mathf.Acos(current_angle), Mathf.Asin(current_angle));
        //Set the new position magnitude to the distance
        newPos = newPos.normalized * shield_distance;
        //Add the value to the parent position and set the current position to that
        this.transform.position = parent.transform.position + (Vector3)newPos;


    }

    private void ComputeHealthRecharge()
    {
        //If health is full don't bother checking
        if(shield_health != MaxHealth)
        {
            //If the old value for the health is not the current shield health, 
            //the shield took damage so reset the recharge timer
            if(old_health != shield_health)
            {
                old_health = shield_health;
                currTimer = rechargeTimer;
            }
            //Decrease the shield timer
            else
            {
                currTimer -= Time.deltaTime;
            }

            //If the shield timer is at 0, then reset the shield charge to full and reset timer and charge values
            if(currTimer <= 0)
            {
                shield_health = MaxHealth;
                old_health = MaxHealth;
                currTimer = rechargeTimer;
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        //TODO on collision with a projectile, damage the shield health

    }

}
