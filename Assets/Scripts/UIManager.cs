using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] ui_Booms;
    //점수
    public Text scoreText;
    public int score;

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
        score = 0;    
    }

    //폭탄 아이템을 체크하는 함수
    public void BoomCheck(int boomCount)
    {
        for (int i = 0; i < ui_Booms.Length; i++)
        {
            if (i + 1 <= boomCount)
                ui_Booms[i].SetActive(true);
            else
                ui_Booms[i].SetActive(false);
        }
    }
    // 스코어 증가 함수
    public void ScoreAdd(int _socre)
    {
        score += _socre;
        scoreText.text = score.ToString();
    }
}
