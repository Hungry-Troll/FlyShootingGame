using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundImageRootController : MonoBehaviour
{
    public GameObject[] backGroundImage;
    float height;
    float speed;
    public float gap;
    int other;
    /// <summary>
    /// ///////
    /// </summary>

    float leftPosX;
    float rightPosY;
    float xScreenHalfSize;
    float yScreenHalfSize;


    private void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosY = xScreenHalfSize * 2 * backGroundImage.Length;

        speed = 50.0f;
/*        gap = 0;
        height = 40.0f;
        other = int.MinValue;*/
    }

    private void Update()
    {
        for (int i = 0; i < backGroundImage.Length; i++)
        {
            backGroundImage[i].gameObject.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if(backGroundImage[i].gameObject.transform.position.y < leftPosX)
            {
                Vector3 nextPos = backGroundImage[i].gameObject.transform.position;
                nextPos = new Vector3(nextPos.x + rightPosY, nextPos.y, nextPos.z);
                backGroundImage[i].gameObject.transform.position = nextPos;
            }
        }


        //Move();
    }

    void Move()
    {
/*        for (int i = 0; i < backGroundImage.Length; i++)
        {
            backGroundImage[i].gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (backGroundImage[i].gameObject.transform.position.y <= -height)
            {
                if (i == 0)
                    other = 1;
                else
                    other = 0;

                float gap = backGroundImage[i].gameObject.transform.position.y + height;
                float PosY1 = backGroundImage[i].gameObject.transform.position.y;
                float PosY2 = backGroundImage[other].gameObject.transform.position.y;
*//*                Debug.LogError(PosY1);
                Debug.LogError(PosY2);
                float sum = Mathf.Abs(backGroundImage[i].gameObject.transform.position.y) + Mathf.Abs(backGroundImage[other].gameObject.transform.position.y) + gap;

                if (sum != 40.00000f)
                {
                    sum = sum - 40.00000f;
                    backGroundImage[i].gameObject.transform.position = new Vector3(0, sum, 0);
                }*//*

                backGroundImage[i].gameObject.transform.position = new Vector3(0, Mathf.Abs(PosY1) + Mathf.Abs(PosY2) + gap, 0);
            }
        }*/
    }
} 



