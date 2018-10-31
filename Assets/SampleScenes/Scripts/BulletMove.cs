using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 6f;
    Transform myTransform;
    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.left * Time.deltaTime * speed);
        Destroy(this.gameObject, 1f);
    }
}
