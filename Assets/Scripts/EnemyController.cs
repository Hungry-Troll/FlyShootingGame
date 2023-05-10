using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region
    public GameObject enemyBullet;
    GameObject player;
    PlayerController playerController;
    float fireDelay;

    Animator animator;
    bool onDead;
    float time;
    //�̵�����
    float moveSpeed;
    Rigidbody2D rg2D;
    //������
    public GameObject[] item;
    //Hp
    int hp;
    //�±� �ӽ� ����
    public string tagName;
    //����
    int score;
    //����
    public AudioSource sound;
    #endregion
    void Start()
    {
        animator = GetComponent<Animator>();
        onDead = false;
        time = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        // �̵�����
        rg2D = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(5.0f, 7.0f);
        fireDelay = 2.5f;
        if (gameObject.CompareTag("ItemDropEnemy"))
            hp = 3;
        else
            hp = 1;
        tagName = gameObject.tag;
        score = 10;
        Move();
    }
    public void FireBullet()
    {
        if (player == null)
            return;

        fireDelay += Time.deltaTime;
        if (fireDelay > 3f)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            fireDelay -= 3f;
        }
    }
    void Update()
    {
        if (onDead)
        {
            time += Time.deltaTime;
        }
        if (time > 0.6f)
        {
            Destroy(gameObject);
            if (tagName == "ItemDropEnemy")
            {
                int temp = Random.Range(0, 2);
                Instantiate(item[temp], transform.position, Quaternion.identity);
            }
        }
        FireBullet();
    }
    private void Move()
    {
        if (player == null)
            return;
        Vector3 distance = player.transform.position - transform.position;
        Vector3 dir = distance.normalized;
        rg2D.velocity = dir * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            hp = hp - playerController.Damage;
        }
        if (collision.CompareTag("BoomMissile"))
        {
            hp = hp - playerController.BoomDamage;
        }
        if (collision.CompareTag("BlockCollider"))
        {
            OnDisapper();
        }
        if (hp <= 0)
        {
            animator.SetInteger("State", 1);
            OnDead();
        }
    }

    private void OnDead()
    {
        onDead = true;
        if(gameObject.tag !="Untagged")
        {
            // ���ھ� ���� �ڵ� �ۼ�
            UIManager.instance.ScoreAdd(score);
            SoundManager.instance.enemyDeadSound.Play();
        }
        gameObject.tag = "Untagged";
    }

    private void OnDisapper()
    {
        Destroy(gameObject);
    }
}
