using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public PlayerController playerController;
    public Vector3 playerPos;
    public int lifeCount;

    public static GameManager instance;
    public BossController bossController;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        lifeCount = 2;
        UIManager.instance.LifeCheck(lifeCount);
        CreatePlayer();
    }
    // �÷��̾� ����
    public void CreatePlayer()
    {
        if (lifeCount >= 0)
        {
            GameObject player = Instantiate(playerPrefab);
            float x = Random.Range(-9.0f, 9.0f);
            float y = -18.0f;
            playerPos = new Vector3(x, y, 0);
            player.transform.position = playerPos;
            playerController = player.GetComponent<PlayerController>();
            UIManager.instance.BoomCheck(playerController.Boom);
        }    
    }
    // �÷��̾� ������ ����
    public void PlayerLifeRemove()
    {
        lifeCount--;
    }
    // �÷��̾� �������� ���� ���ӿ��� Ȯ��
    public void GameOverCheck()
    {
        if(lifeCount < 0)
        {
            UIManager.instance.GameOver();
        }
    }
}
