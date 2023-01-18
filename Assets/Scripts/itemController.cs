using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    protected GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 0.05f);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            ItemGain();
        }
        if (collision.CompareTag("BlockCollider"))
        {
            Destroy(gameObject);
        }
    }
    // 자식 클래스에서 처리
    protected virtual void ItemGain() { }
}
