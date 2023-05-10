using UnityEngine;

public class BossController : MonoBehaviour
{
    //
    GameObject player;
    PlayerController playerController;
    // ü�¹�
    public float hp1; //�ʷϻ�
    public float hp2; //������
    //
    Animator animator;
    //
    bool onDead;
    bool isSpwan;
    //
    //����
    int score;
    //
    float time;
    //
    Transform spwanMovePos;
    //
    float speed;

    //�Ѿ� ��� ��ġ
    public Transform LAttackPos;
    public Transform RAttackPos;
    //�Ѿ�
    public GameObject bossBullet;
    //�Ѿ� ������
    float fireDelay;
    //�ִϸ��̼� ������
    float animDelay;

    //�ִϸ��̼� ���� Ȯ�ο�
    // 0 : ���, �̵� 
    // 1 : L���� 
    // 2 : R����
    // 3 : Die
    int animNumber; 

    // Start is called before the first frame update
    void Awake()
    {
        hp1 = 150.0f;
        hp2 = 150.0f;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        spwanMovePos = GameObject.Find("BossSpwan").GetComponent<Transform>();

        animator = GetComponent<Animator>();

        onDead = false;
        isSpwan = true;

        score = 1000;

        speed = 10;

        animNumber = 0; // ���
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpwan)
        {
            BossSpwan();
        }
        if (onDead)
        {
            time += Time.deltaTime;
        }
        if (time > 0.6f)
        {
            Destroy(gameObject);
        }

        // �Ѿ� �߻� �ִϸ��̼�
        if (hp1 > 0 && isSpwan == false)
        {
            fireDelay += Time.deltaTime;
            // ���� �����̰� 2.0�� ������ L���� ���°� �ƴϸ�
            if (fireDelay > 1.0f && animNumber != 1)
            {
                //L����
                animNumber = 1;
            }
            if (fireDelay > 1.5f)
            {
                // ���
                animNumber = 0;
                fireDelay -= fireDelay;
            }
        }
        if (hp1 <= 0)
        {
            fireDelay += Time.deltaTime;
            // ���� �����̰� 1.0�� ������ R���� ���°� �ƴϸ�
            if (fireDelay > 1.0f && animNumber != 2)
            {
                //L����
                animNumber = 2;
            }
            if (fireDelay > 1.5f)
            {
                // ���
                animNumber = 0;
                fireDelay -= fireDelay;
            }
        }
        AnimationSystem();
    }

    // �ִϸ��̼Ǹ� ���� ��������
    void AnimationSystem()
    {
        // ��� �̵�
        if (animNumber == 0)
        {
            animator.SetTrigger("Idle");
        }
        // L����
        if (animNumber == 1)
        {
            animator.SetTrigger("LAttack");
        }
        // R����
        if (animNumber == 2)
        {
            animator.SetTrigger("RAttack");
        }
        // Die
        if (animNumber == 3)
        {
            animator.SetTrigger("Die");
        }
    }

    public void PlayerFind()
    {

    }

    void LAttack()
    {
        if (player == null)
            return;

        Instantiate(bossBullet, LAttackPos.position, Quaternion.identity);
        fireDelay -= 1f;
    }

    void RAttack()
    {
        if (player == null)
            return;

        Instantiate(bossBullet, RAttackPos.position, Quaternion.identity);
        fireDelay -= 1f;
    }

    private void OnDead()
    {
        onDead = true;
        UIManager.instance.isBossSpwan = false;
        if (gameObject.tag != "Untagged")
        {
            // ���ھ� ���� �ڵ� �ۼ�
            UIManager.instance.ScoreAdd(score);
            SoundManager.instance.enemyDeadSound.Play();
        }
        gameObject.tag = "Untagged";
    }

    private void BossSpwan()
    {
        transform.position = Vector3.MoveTowards(transform.position, spwanMovePos.position, Time.deltaTime * speed);
        if (transform.position == spwanMovePos.position)
        {
            isSpwan = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            if(hp1 > 0)
            {
                hp1 = hp1 - playerController.Damage;
            }
            else
            {
                hp2 = hp2 - playerController.Damage;
            }
        }
        if (collision.CompareTag("BoomMissile"))
        {
            if(hp1 > 0)
            {
                hp1 = hp1 - playerController.BoomDamage;
            }
            else
            {
                hp2 = hp2 - playerController.BoomDamage;
            }
        }
        if (hp2 <= 0)
        {
            animator.SetTrigger("Die");
            OnDead();
        }
    }

}
