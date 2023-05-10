using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] ui_Booms;
    //점수
    public Text scoreText;
    public Text highScoreText;
    public int score;
    public int highScore;
    //라이프
    public GameObject[] ui_Life;
    //암막
    public Image blackOut_Curtain;
    float blackOut_Curtain_value;
    float blackOut_Curtain_speed;
    //게임오버
    public Image gameOverImage;
    //보스
    public Image hpbarFrame;
    public Image hpbar1;
    public Image hpbar2;
    public float MaxHp1;
    public float MaxHp2;
    public BossController bossController;
    public bool isBossSpwan;
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
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        blackOut_Curtain_value = 1.0f;
        blackOut_Curtain_speed = 0.5f;

        isBossSpwan = false;
    }

    void Update()
    {
        if(blackOut_Curtain_value > 0)
        {
            HideBlackOut_Curtain();
        }
        if(isBossSpwan)
        {
            BossHpBarCheck();
        }
        if(isBossSpwan == false)
        {
            hpbarFrame.gameObject.SetActive(false);
            hpbar1.gameObject.SetActive(false);
            hpbar2.gameObject.SetActive(false);
        }
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
    //라이프 체크 함수
    public void LifeCheck(int lifeCount)
    {
        for (int i = 0; i < ui_Life.Length; i++)
        {
            if (i + 1 <= lifeCount)
                ui_Life[i].SetActive(true);
            else
                ui_Life[i].SetActive(false);
        }
    }

    public void HideBlackOut_Curtain()
    {
        blackOut_Curtain_value -= Time.deltaTime * blackOut_Curtain_speed;
        blackOut_Curtain.color = new Color(0.0f, 0.0f, 0.0f, blackOut_Curtain_value);
        // 1 = 255 
    }

    public void GameOver()
    {
        gameOverImage.gameObject.SetActive(true);
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }
        highScoreText.text = highScore.ToString();
    }
    public void ReturnTitle()
    {
        SceneManager.LoadScene("Title");

        Destroy(UIManager.instance.gameObject);
        Destroy(GameManager.instance.gameObject);
        Destroy(SoundManager.instance.gameObject);
    }

    public void BossHpBarCheck()
    {
        hpbarFrame.gameObject.SetActive(true);
        hpbar1.gameObject.SetActive(true);
        hpbar2.gameObject.SetActive(true);

        hpbar1.fillAmount = bossController.hp1 / MaxHp1;
        hpbar2.fillAmount = bossController.hp2 / MaxHp2;
    }
}
