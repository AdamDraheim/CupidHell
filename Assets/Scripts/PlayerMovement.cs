using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    float countdown;

    public Rigidbody myRigidbody;
    public Camera cam;

    private Vector3 movement;
    private Vector3 movementVelocity;

    //Shield variables
    private int health = 99;
    public int regenSpeed = 1;
    public bool isActive = false;
    public GameObject shield;
    public Collision enemeyBullet;

    public BulletController theGun;
    //Shooty variables
    public bool isStream;
    public bool isSpray;
    public bool isMachine;

    void start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            theGun.bulletSpeed = 20f;
            theGun.timeBetweenShots = 0.001f;
        }
        else if (Input.GetKeyDown("1"))
        {
            theGun.bulletSpeed = 8f;
            theGun.timeBetweenShots = 0.1f;
        }
        //Player Input
        movementVelocity = movement * moveSpeed;

        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

        }
        if (!isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!isActive)
            {
                isActive = true;
                theGun.isFiring = false;
                shield.SetActive(true);
            }
            else
            {
                isActive = false;
                shield.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        Debug.Log(health);
        myRigidbody.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, Input.GetAxisRaw("Vertical") * moveSpeed);
        countdown += Time.deltaTime;
        if (countdown > 0.01)
        {
            countdown = 0;
            if (isActive)
            {
                if (health > 0)
                {
                    health -= regenSpeed;
                }
            }

            else
            {
                if (health <= 99)
                {
                    health += regenSpeed;
                }
            }

            if (health <= 0)
            {
                isActive = false;
                shield.SetActive(false);
                health += regenSpeed;
            }
            if (health <= 0)
            {
                isActive = false;
                shield.SetActive(false);
                health += regenSpeed;
            }
       
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy Bullet") {
            health -= 5;
        }
    }
}
