using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    public float jumpMaxDistance;
    private bool isJumping = false;
    private bool isFalling = false;
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
        pas = jumpMaxDistance / 15;
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
        Debug.Log("ok");
        if (other.tag == "Platform")
            isFalling = false;
        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFalling = true;
    }


}
