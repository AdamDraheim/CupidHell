using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public string powerupName;

    public float pickupRange;

    private GameObject player;

    public void Update()
    {

        if (player == null)
        {

            player = GameObject.Find("Player");

            if(player.GetComponent<PlayerStats>() == null)
            {
                player = null;
            }

        }
        else
        {
            Vector2 pos = player.transform.position;
            if (Vector2.Distance(this.transform.position, pos) <= pickupRange)
            {
                player.GetComponent<PlayerStats>().ChargePower(powerupName);
                Destroy(this.gameObject);
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, pickupRange);
    }

}
