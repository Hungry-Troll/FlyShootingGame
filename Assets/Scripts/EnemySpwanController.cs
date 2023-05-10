using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanController : MonoBehaviour
{
    // ������ġ
    public Transform[] enemySpwns;
    // �� ������
    public GameObject[] enemyGameObject;
    // �ð��� ��� ����
    float time;
    // �� ���� �ð�
    float respwnTime;
    // �� ���� ����
    int enemyCount;
    // ���� ���� ������ �����ϴ� �迭
    int[] randomCount;
    // ���̺� >> ���� ���
    int wave;
    // �÷��̾� ����
    // GameObject player;
    // ���� ����
    bool bossCreate;
    public GameObject bossGameObject;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        respwnTime = 4.0f;
        enemyCount = 5;
        randomCount = new int[enemyCount];
        wave = 0;
        bossCreate = false;
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        // ���� ����
        if (wave >= 5 && bossCreate == false)
            BossCreate();
    }
    // �ð��� üũ�ϴ� �Լ�
    void Timer()
    {
        time += Time.deltaTime;
        if(time > respwnTime)
        {
            RandomPos();
            EnemyCreate();
            wave++;
            time -= time;
        }
    }

    void RandomPos()
    {
        // ���� ��ġ�� ���� ����
        for (int i = 0; i < enemyCount; i++)
        {
            randomCount[i] = Random.Range(0, 9);
        }
    }

    void EnemyCreate()
    {
        //if (player == null)
        //    return;

        if (GameManager.instance.lifeCount < 0)
            return;

        for (int i = 0; i < enemyCount; i++)
        {
            // ���� �� ����
            int tmpCnt = Random.Range(0, enemyGameObject.Length);
            // ����
            GameObject tmp = GameObject.Instantiate(enemyGameObject[tmpCnt]);
            // ��ġ
            tmp.transform.position = enemySpwns[randomCount[i]].position;
            // ���� ��ġ�� �����ϱ� ���� ������ ��ġ �� ����
            float tmpX = tmp.transform.position.x;
            float result = Random.Range(tmpX - 2.0f, tmpX + 2.0f);
            tmp.transform.position = new Vector3(result, tmp.transform.position.y, transform.position.z);
        }
    }

    void BossCreate()
    {
        bossCreate = true;
        GameObject tmp = GameObject.Instantiate(bossGameObject);
        int randomCount = Random.Range(0, 9);
        tmp.transform.position = enemySpwns[randomCount].position;
        BossController bossController = tmp.GetComponent<BossController>();

        UIManager.instance.isBossSpwan = true;
        UIManager.instance.MaxHp1 = bossController.hp1;
        UIManager.instance.MaxHp2 = bossController.hp2;
        UIManager.instance.bossController = bossController;
        // ���ӸŴ����� ���� ��Ʈ�ѷ� �Ѱ���
        GameManager.instance.bossController = bossController;
    }
}
