using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController2 : MonoBehaviour
{
    public float speed;
    float time;
    // Start is called before the first frame update
    private void Start()
    {
        speed = 30.0f;
        time = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        FireBullet();
        DestroyBullet();
    }

    private void FireBullet()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        time += Time.deltaTime;
        if (time > 5.0f)
        {
            Destroy(gameObject);
        }
    }
}
