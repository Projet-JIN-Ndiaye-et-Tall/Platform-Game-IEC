﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputController : MonoBehaviour {
    public float jumpMaxDistance = 50;
    private bool isJumping = false;
    private bool isFalling = true;
    private float jumpedDistance; // 
    private float pas = 10f;
    private CircleCollider2D bc;
    private Rigidbody2D rb;

    void Awake()
    {

        bc = GetComponent<CircleCollider2D>();
        bc.isTrigger = true;

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    // Use this for initialization
    void Start () {
        pas = jumpMaxDistance / 100;

	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        

        if (x != 0)
        {
            transform.position += 10*x*transform.right * Time.deltaTime; 
        }

        if (Input.GetButtonUp("Jump") && !isFalling && !isJumping)
        {
            jumpedDistance = 0.0f;
            isJumping = true;
        }

        if (isJumping)
        {
            if(jumpedDistance < jumpMaxDistance)
            {
                jumpedDistance += pas;
                transform.position += pas * transform.up * Time.deltaTime;
            }
            else
            {
                isFalling = true;
                isJumping = false;
            }
            
        }
        else if (isFalling)
        {
            jumpedDistance -= pas;
            transform.position -= pas * transform.up * Time.deltaTime;
        }
      
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.tag == "Platform")
        {
            Debug.Log("MIN:"+other.bounds.min.y);
            Debug.Log("MAX:"+other.bounds.max.y);
            Debug.Log("Position:"+transform.position.y);
            isJumping = false;
            if (other.bounds.min.y < transform.position.y) {
                Debug.Log("UP");
                isFalling = false;
            }

            if(other.bounds.min.y >= transform.position.y)
            {
                Debug.Log("DOWN");
                isFalling = true;
                isJumping = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFalling = true;
    }
 
   
}
