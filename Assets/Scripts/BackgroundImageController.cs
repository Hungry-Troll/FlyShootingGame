using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImageController : MonoBehaviour
{
    float speed;
    float hight;
    BoxCollider2D boxCollider;
    void Start()
    {
        speed = 3;
        boxCollider = GetComponent<BoxCollider2D>();
        hight = boxCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.y * 2 <= -hight)
        {
            RePosition();
        }
    }

    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void RePosition()
    {
        Vector3 offset = new Vector3(0, hight * 2.5f, 0);
        transform.position = transform.position + offset;
    }
}
