﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    EnableShoot es;
    public GameObject bullet;
    public GameObject spawnPoint;
    private BoxCollider2D bc;
    public bool enableShoot;

    // Use this for initialization
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        es = GetComponent<EnableShoot>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //if (enableShoot)
        //{
            //Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
          
       // }
    }
}
