using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Position { AIR, HorizontalPlatform, VerticalPlatform };

public class InputController : MonoBehaviour
{
    public float jumpMaxDistance;
    private bool isJumping = false;
    private bool isFalling = true;
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
    void Start()
    {
        pas = jumpMaxDistance / 50;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            if (currentPosition == Position.HorizontalPlatform || currentPosition == Position.AIR)
                transform.position += 10 * x * transform.right * Time.deltaTime;
            else
                transform.position += 10 * y * transform.up * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") && !isFalling && !isJumping)
        {
            jumpedDistance = 0.0f;
            isJumping = true;
        }

        if (isJumping)
        {
            if (jumpedDistance < jumpMaxDistance)
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
            Debug.Log("SIZE:" + other.bounds.size);
            if (other.bounds.size.x < other.bounds.size.y)
            {
                currentPosition = Position.VerticalPlatform;
            }
            else
            {
                currentPosition = Position.HorizontalPlatform;
            }

            isJumping = false;


            if (other.bounds.min.x > transform.position.x || other.bounds.max.x < transform.position.x)//LEFT or RIGHT
            {
                Debug.Log("SIDE");
                if (currentPosition == Position.VerticalPlatform)
                {
                    isFalling = false;
                }
            }
            else if (other.bounds.min.y < transform.position.y)
            {//TOP
                Debug.Log("TOP");
                isFalling = false;
            }
            else //DOWN
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
        currentPosition = Position.AIR;
    }


}
