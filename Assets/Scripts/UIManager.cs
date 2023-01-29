using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] ui_Booms;

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
    //��ź �������� üũ�ϴ� �Լ�
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
}
