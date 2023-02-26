using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImageController : MonoBehaviour
{
    float speed;
    float height;
    public GameObject other;

    void Awake()
    {
        speed = 30;
        height = 40.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (gameObject.transform.position.y <= -height)
        {
            float gap = gameObject.transform.position.y + height;
            float PosY1 = gameObject.transform.position.y;
            float PosY2 = other.gameObject.transform.position.y;
            Debug.LogError(PosY1);
            Debug.LogError(PosY2);
            gameObject.transform.position = new Vector3(0,Mathf.Abs(PosY1) + Mathf.Abs(PosY2) + gap, 0);
        }

    }

    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }


}
