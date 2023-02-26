using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    float height;
    float speed;
    public BoxCollider2D collider2D;
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        height = collider2D.size.y;
        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.y <= -height)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(0, height * 2f);
        transform.position = (Vector2)transform.position + offset;
    }

    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
