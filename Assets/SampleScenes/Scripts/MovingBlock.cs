using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour {

    public GameObject[] platforms;
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
            for(int i=0; i < platforms.Length; i++)
            {
                platforms[i].GetComponent<Animator>().enabled = true;
            }
            
          
        }
    }
    
}
