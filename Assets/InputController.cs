using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Position { AIR, HorizontalPlatform, VerticalPlatform};

public class InputController : MonoBehaviour {
    public float jumpMaxDistance;
    public int nbJumpMax = 2;
    private bool isJumping = false;
    private bool isFalling = true;
    private int nbJump = 0;
    private float jumpedDistance; // 
    private float pas = 10f;
    private CircleCollider2D bc;
    private Rigidbody2D rb;
    Position currentPosition;
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
        jumpedDistance = 0;

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Jumping:"+isJumping);
        Debug.Log("Distance:" + jumpedDistance);
        Debug.Log("Position:" + transform.position);
        Debug.Log("PlatformOrientation:" + currentPosition);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y!=0)
        {
            if(currentPosition == Position.HorizontalPlatform || currentPosition == Position.AIR)
                transform.position += 10*x*transform.right * Time.deltaTime;
            else
                transform.position += 10 * y * transform.up * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") && nbJump < nbJumpMax && !isJumping)
        {
            jumpedDistance = 0.0f;
            isJumping = true;
            isFalling = false;
            nbJump++;
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
                jumpedDistance = 0;
            }
            
        }
        else if (isFalling)
        {
            transform.position -= pas * transform.up * Time.deltaTime;
        }
      
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.tag == "Platform")
        {
           
            Debug.Log("SIZE:"+other.bounds.size);
            if (other.bounds.size.x < other.bounds.size.y)
            {
                currentPosition = Position.VerticalPlatform;
            }
            else
            {
                currentPosition = Position.HorizontalPlatform;
            }

            isJumping = false;

            float lx = other.bounds.min.x;
            float rx = other.bounds.max.x;
            if ( lx > transform.position.x ||  rx < transform.position.x)//LEFT or RIGHT
            {
                Debug.Log("SIDE");
                if (currentPosition == Position.VerticalPlatform)
                {
                    isFalling = false;
                    nbJump = 0;
                }
            }
            else if (other.bounds.min.y < transform.position.y) {//TOP
                Debug.Log("TOP");
                isFalling = false;
                nbJump = 0;
            }
           else //DOWN
            {
                Debug.Log("DOWN");
                isFalling = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFalling = true;
        currentPosition = Position.AIR;
    }
 
   
}
