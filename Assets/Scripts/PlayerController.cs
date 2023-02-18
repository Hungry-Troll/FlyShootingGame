using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region
    float x;
    float y;
    public Vector3 limitMax;
    public Vector3 limitMin;
    Vector3 temp;
    public GameObject[] prefabBullet;
    float time;
    public float speed;

    float fireDelay;
    Animator animator;
    bool onDead;
    // æ∆¿Ã≈€
    public int Damage;
    public int Boom;
    // ∆¯≈∫
    public GameObject BoomMissile;
    public int BoomPosY;
    public int BoomDamage;

    #endregion
    private void Start()
    {
        time = 0;
        fireDelay = 0;
        speed = 10.0f;

        animator = GetComponent<Animator>();
        onDead = false;

        Damage = 1;
        Boom = 0;

        BoomPosY = -30;
        BoomDamage = 30;
    } 
    // Update is called once per frame
    private void Update()
    {
        Move();
        FireBullet();
        OnDeadCheck();
        FireBoom();
    }
    public void Move()
    {
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(x, y, 0));

        if (transform.position.x > limitMax.x)
        {
            temp.x = limitMax.x;
            temp.y = transform.position.y;
            transform.position = temp;
        }
        if (transform.position.y > limitMax.y)
        {
            temp.y = limitMax.y;
            temp.x = transform.position.x;
            transform.position = temp;
        }
        if (transform.position.x < limitMin.x)
        {
            temp.x = limitMin.x;
            temp.y = transform.position.y;
            transform.position = temp;
        }
        if (transform.position.y < limitMin.y)
        {
            temp.y = limitMin.y;
            temp.x = transform.position.x;
            transform.position = temp;
        }
    }
    public void FireBullet()
    {
        fireDelay += Time.deltaTime;
        //Debug.Log("Fire " + fireDelay);
        if (fireDelay > 0.3f)
        {
            Instantiate(prefabBullet[Damage - 1], transform.position, Quaternion.identity);
            fireDelay -= 0.3f;
        }
    }

    public void FireBoom()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space!!");
            if (Boom >= 1)
            {
                GameObject go = Instantiate(BoomMissile, transform.position, Quaternion.identity);
                go.transform.position = new Vector3(transform.position.x, BoomPosY, transform.position.z);
                Boom--;
                UIManager.instance.BoomCheck(Boom);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(limitMin, new Vector2(limitMax.x, limitMin.y));
        Gizmos.DrawLine(limitMin, new Vector2(limitMin.x, limitMax.y));
        Gizmos.DrawLine(limitMax, new Vector2(limitMax.x, limitMin.y));
        Gizmos.DrawLine(limitMax, new Vector2(limitMin.x, limitMax.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyBullet"))
        {
            animator.SetInteger("State", 1);
            onDead = true;
        }
    }

    private void OnDeadCheck()
    {
        if (onDead)
        {
            time += Time.deltaTime;
        }
        if (time > 0.6f)
        {
            Destroy(gameObject);
            GameManager.instance.PlayerLifeRemove();
            GameManager.instance.CreatePlayer();
            UIManager.instance.LifeCheck(GameManager.instance.lifeCount);
        }
    }
}
