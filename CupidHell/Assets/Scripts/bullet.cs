using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //variables
    public GameObject bullet_obj;
    public float maxDistance;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;
        if (maxDistance > 2)
        {
            Destroy(bullet_obj);
        }
    }
}
