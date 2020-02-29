using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float health = 35f;
    public GameObject heartCube;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            health += 5;
            Object.Destroy(heartCube);
        }
        if (collision.gameObject.tag == "Enemy Bullet")
        {
            health -= 5;
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("You stinky");
            Destroy(this.gameObject);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
