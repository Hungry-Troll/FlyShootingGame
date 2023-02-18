using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    protected GameObject player;
    protected float speed;
    protected int score;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 10.0f;
        score = 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            ItemGain();
        }
        if(collision.CompareTag("BlockCollider"))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void ItemGain() { }
}
