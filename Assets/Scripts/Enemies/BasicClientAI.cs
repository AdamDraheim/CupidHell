using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicClientAI : MonoBehaviour
{
    private float health;
    //public int Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Hurt()
    {
        float damage = 1.0f;
        health -= damage;
    }

    void OnCollisonEnter(GameObject other)
    {
        if (other.tag.Equals("Bullet"))
        {
            Hurt();
            Destroy(other);
        }
    }
}
