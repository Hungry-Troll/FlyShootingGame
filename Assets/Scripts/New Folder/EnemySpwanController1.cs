using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanController1 : MonoBehaviour
{
    // 생성위치
    public Transform[] enemySpwans;
    // 적 프리팹
    public GameObject[] enemyGameObject;
    // 시간을 재는 변수
    float time;
    // 적 생성 시간
    float respwanTime;
    // 적 생성 숫자
    int enemyCount;
    // 랜덤 숫자 변수를 저장하는 배열
    int []randomCount;
    // 웨이브 >> 추후 사용
    int wave;
    // 플레이어 변수
    GameObject player;
    void Start()
    {
        time = 0;
        respwanTime = 4.0f;
        enemyCount = 5;
        randomCount = new int[enemyCount];
        wave = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Timer();
    }
    // 시간을 체크하는 함수
    void Timer()
    {
        time += Time.deltaTime;
        if (time > respwanTime)
        {
            RandomPos();
            EnemyCreate();
            wave++;
            time -= time;
        }
    }

    // 랜덤 숫자 함수
    void RandomPos()
    {
        // 랜덤 위치를 위한 숫자
        for (int i = 0; i < enemyCount; i++)
        {
            randomCount[i] = Random.Range(0, 9);
        }
    }

    // 적을 생성하는 함수
    void EnemyCreate()
    {
        if (player == null)
            return;

        for (int i = 0; i < enemyCount; i++)
        {
            // 랜덤 적 선택
            int tmpCnt = Random.Range(0, enemyGameObject.Length);
            // 생성
            GameObject tmp = GameObject.Instantiate(enemyGameObject[tmpCnt]);
            // 위치
            tmp.transform.position = enemySpwans[randomCount[i]].position;
            // 동일 위치를 방지하기 위한 조금의 위치 값 수정
            float tmpX = tmp.transform.position.x;
            float result = Random.Range(tmpX - 2.0f, tmpX + 2.0f);
            tmp.transform.position = new Vector3(result, tmp.transform.position.y, transform.position.z);
        }
    }
}
