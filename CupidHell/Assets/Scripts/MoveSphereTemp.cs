﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphereTemp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 3);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        transform.position = new Vector3(0, 0, -4f);
    }
}