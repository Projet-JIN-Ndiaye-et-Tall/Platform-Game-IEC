using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject bullet;
    public GameObject spawnPoint;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            for(int i = 0; i < 10; i++)
            {
                Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
            
        }
    }

}
