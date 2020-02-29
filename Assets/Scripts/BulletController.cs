using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public bool isFiring;

    public float bulletSpeed;
    public bullet bullet_thing;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    //Testing flamethrower yayyyyyyyyyyyyy
    public int pelletCount;
    public float spreadAngle;
    public GameObject pellet;
    public Transform BarrelExit;
    List<Quaternion> pellets;
    public bool isSpray = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++){
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    void Fire()
    {
        int i = 0;
        foreach (Quaternion quat in pellets)
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, firePoint.position, firePoint.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.right * bulletSpeed);
            i++;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (isSpray)
            {
                Fire();
            }
            else
            {
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    bullet newBullet = Instantiate(bullet_thing, firePoint.position, firePoint.rotation) as bullet;
                    newBullet.speed = bulletSpeed;
                }
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
