using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class DestructibleCover : MonoBehaviour

{

    public int health;



    // Start is called before the first frame update

    void Start()

    {

        health = 3;

    }



    // Update is called once per frame

    void Update()

    {



    }



    void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.tag == "Bullet")

        {

            health = health - 1;

            Destroy(collision.gameObject);

            if (health < 1)

            {

                Destroy(gameObject);

            }

        }

    }

}
