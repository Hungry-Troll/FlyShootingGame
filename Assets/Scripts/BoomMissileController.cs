using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMissileController : MonoBehaviour
{
    public float speed;
    float time;
    // Start is called before the first frame update
    private void Start()
    {
        speed = 10.0f;
        time = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        FireBoom();
        DestroyBullet();
    }

    private void FireBoom()
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
