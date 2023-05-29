using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    #region
    //
    public GameObject player;
    public PlayerController playerController;
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
    #endregion
    //�ִϸ��̼� ���� Ȯ�ο�
    // -1 : ���, �̵� �ݺ�
    // 0 : ���, �̵�
    // 1 : L����
    // 2 : R����
    // 3 : Die
    int animNumber;
    // �ǰݰ���
    public SpriteRenderer spriteRenderer;
    Color currentColor;

    // Start is called before the first frame update
    void Awake()
    {
        hp1 = 150.0f;
        hp2 = 150.0f;
    }
    void Start()
    {
        spwanMovePos = GameObject.Find("BossSpwan").GetComponent<Transform>();
        animator = GetComponent<Animator>();

        onDead = false;
        isSpwan = true;

        score = 1000;

        speed = 10;

        animNumber = 0;

        currentColor = spriteRenderer.color;
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
        if( player == null && GameManager.instance.lifeCount >= 0)
        {
            PlayerFind();
        }
        FireBullet();
        AnimationSystem();
    }

    public void PlayerFind()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    //�ִϸ��̼� ���� Ȯ�ο�
    // -1 : ���, �̵� �ݺ�
    // 0 : ���, �̵�
    // 1 : L����
    // 2 : R����
    // 3 : Die
    void FireBullet()
    {
        // �Ѿ� �߻� �ִϸ��̼�
        if (hp1 > 0 && isSpwan == false)
        {
            fireDelay += Time.deltaTime;
            // ���� �����̰� 1.0�� ������ L���� ���°� �ƴϸ�
            if (fireDelay > 1.0f && animNumber != 1)
            {
                // L����
                animNumber = 1;
                fireDelay -= fireDelay;
            }
        }
        if (hp1 <= 0)
        {
            fireDelay += Time.deltaTime;
            // ���� �����̰� 1.0�� ������ R ���� ���°� �ƴϸ�
            if (fireDelay > 1.0f && animNumber != 2)
            {
                // R����
                animNumber = 2;
                fireDelay -= fireDelay;
            }
        }
    }

    // �ִϸ��̼��� ���� ����
    void AnimationSystem()
    {
        // ��� �̵�
        if (animNumber == 0)
        {
            StartCoroutine(Co_Idle());
        }
        if (animNumber == 1)
        {
            StartCoroutine(Co_LAttack());
        }
        if (animNumber == 2)
        {
            StartCoroutine(Co_RAttack());
        }
    }
    //�ִϸ��̼� ���� Ȯ�ο�
    // -1 : ���, �̵� �ݺ�
    // 0 : ���, �̵�
    // 1 : L����
    // 2 : R����
    // 3 : Die

    IEnumerator Co_Idle()
    {
        animNumber = -1;
        animator.SetTrigger("Idle");
        yield return new WaitForSeconds(0.6f);
    }

    IEnumerator Co_LAttack()
    {
        animNumber = -1;
        animator.SetTrigger("LAttack");
        yield return new WaitForSeconds(0.6f);
        animNumber = 0;
    }

    IEnumerator Co_RAttack()
    {
        animNumber = -1;
        animator.SetTrigger("RAttack");
        yield return new WaitForSeconds(0.6f);
        animator.SetTrigger("RAttack");
        yield return new WaitForSeconds(0.6f);
        animator.SetTrigger("RAttack");
        yield return new WaitForSeconds(0.6f);
        animNumber = 0;
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
            StartCoroutine(OnDamagedEffect());
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
            StartCoroutine(OnDamagedEffect());
        }
        if (hp2 <= 0)
        {
            animator.SetTrigger("Die");
            OnDead();
        }
    }

    IEnumerator OnDamagedEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = currentColor;
    }
}
